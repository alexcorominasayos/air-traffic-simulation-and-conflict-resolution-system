using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseDatos;

namespace FlightLib
{
    public class FlightPlanList
    {
        //List<FlightPlan> vector = new List<FlightPlan>();
        private List<FlightPlan> vector;
        int TiempoCiclo = 0;

        public FlightPlanList()
        {
            vector = new List<FlightPlan>();
        }
        public void AddFlightPlan(FlightPlan p)
        {
            vector.Add(p);
        }
        public void ClearFlightPlanList()
        {
            vector.Clear();
        }
        public int Count()
        {
            return vector.Count;
        }
        public List<FlightPlan> getVector() 
        {
            return this.vector;
        }
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= vector.Count)
            {
                return null; 
            }
            else
            {
                return vector[i];
            }
        }
        public int GetTiempoCiclo()
        {
            return this.TiempoCiclo;
        }
        public int GetNum()
        {
            return vector.Count;
        }
        public void Mover(double tiempo)
        {
            if (!hasArrived()) 
            { 
                int i = 0;
                while (i < vector.Count)
                {
                    vector[i].Mover(tiempo);
                    i++;
                }
            }
        }
        public void Clear()
        { vector.Clear(); }
        public void copiarFlightplanList(FlightPlanList F)
        {
            this.Clear();
            this.TiempoCiclo = F.GetTiempoCiclo();
            for (int i = 0; i < F.GetNum(); i++)
            {
                FlightPlan temporalFP = new FlightPlan();
                temporalFP.copiarFlightPlan(F.GetFlightPlan(i));
                this.vector.Add(temporalFP);
            }
        }
        public bool hasArrived()
        {
            int i = 0;
            bool arrived = true;
            while (i < this.vector.Count)
            {
                if (GetFlightPlan(i).HasArrived() != true)
                {
                    arrived = false;
                }
                i = i + 1;
            }
            return arrived;
        }
        public void TextFPChanged(List<double>LVOrg, List<double>LVChng, FlightPlanList lista)
        {
            int i = 0;
            bool dif = false;
            while (i < LVOrg.Count)
            {
                if (LVOrg[i] != LVChng[i])
                {
                    dif = true;
                    i = i + 1;
                }
                else
                { i = i + 1; }
            }
            if (dif == true)
            {
                BD comp = new BD();
                comp.Iniciar();
                DataTable dt = comp.GetCompañias();
                comp.Cerrar();
                StreamWriter s = new StreamWriter("Conflict Log Solutions.txt");
                int j = 0;
                while (j<LVOrg.Count)
                {
                    if (LVOrg[j] ==  LVChng[j])
                    { j = j+1; }
                    else
                    {
                        string ID = lista.GetFlightPlan(j).getId().Substring(0, 3);
                        int k = 0;
                        bool found = false;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (ID == row["Identificator"].ToString())
                            {
                                string correo = row["Email"].ToString();
                                string telf = row["Phone"].ToString();
                                string nombre = row["Name"].ToString();
                                s.WriteLine("Data of the company of the affected flight.");
                                s.WriteLine("Name: " + nombre);
                                s.WriteLine("Phone:" + telf);
                                s.WriteLine("Email: " + correo);
                            }
                        }
                        if (found == false)
                        { s.WriteLine("Theres no data of the operator."); }
                        s.WriteLine("The velocity of the flight: " + lista.GetFlightPlan(j).getId() + " should be changed to: " + LVChng[j]);
                        s.WriteLine("");
                        j = j+1;
                    }
                }
                s.Close();
            }
            else
            { 
                StreamWriter s = new StreamWriter("Conflict Log Solutions.txt");
                s.WriteLine("There are no conflicts");
                s.Close();
            }
            
        }

        public void GenerateFPKml(string ruta)
        {
            ruta = ruta + ".kml";
            string elnombre = "Points and trajectories of the Flight Plans";
            string encabezado = "";
            string cuerpo = "";
            string iconos = GetModIcons();
            try
            {
                foreach (FlightPlan fp in this.vector)
                {
                    string id = fp.getId();
                    string alt = "0";
                    string ipx = Convert.ToString(-14.569 + (((6.026 - (-14.569)) / (897 - 0)) * fp.GetInitialPosition().GetX())).Replace(",", ".");
                    string ipy = Convert.ToString(44.849 + (((35.318 - 44.849) / (597 - 0)) * fp.GetInitialPosition().GetY())).Replace(",", ".");
                    string cpx = Convert.ToString(-14.569 + (((6.026 - (-14.569)) / (897 - 0)) * fp.GetCurrentPosition().GetX())).Replace(",", ".");
                    string cpy = Convert.ToString(44.849 + (((35.318 - 44.849) / (597 - 0)) * fp.GetCurrentPosition().GetY())).Replace(",", ".");
                    string fpx = Convert.ToString(-14.569 + (((6.026 - (-14.569)) / (897 - 0)) * fp.GetfinalPosition().GetX())).Replace(",", ".");
                    string fpy = Convert.ToString(44.849 + (((35.318 - 44.849) / (597 - 0)) * fp.GetfinalPosition().GetY())).Replace(",", ".");

                    // Mostramos los puntos iniciales, actuales y finales de las trayectorias de los aviones
                    cuerpo = cuerpo + " <Placemark><name>" + "Initial Position " + id + "</name><styleUrl>#default1</styleUrl><Point><coordinates>" + ipx + "," + ipy + "," + alt;
                    cuerpo = cuerpo + " </coordinates></Point> </Placemark> ";
                    cuerpo = cuerpo + " <Placemark><name>" + "Current Position " + id + "</name><styleUrl>#msn_airports0</styleUrl><Point><coordinates>" + cpx + "," + cpy + "," + alt;
                    cuerpo = cuerpo + " </coordinates></Point> </Placemark> ";
                    cuerpo = cuerpo + " <Placemark><name>" + "Final Position " + id + "</name><styleUrl>#msn_F</styleUrl><Point><coordinates>" + fpx + "," + fpy + "," + alt;
                    cuerpo = cuerpo + " </coordinates></Point> </Placemark> ";

                    // Mostramos las trayectorias de los aviones
                    cuerpo = cuerpo + "<Placemark><name>Trajectory " + id + "</name><styleUrl>#default0</styleUrl><LineString><altitudeMode>clampToGround</altitudeMode><extrude>1</extrude>" +
                        "<tessellate>1</tessellate><coordinates>" + ipx + "," + ipy + "," + alt + " " + fpx + "," + fpy + alt;
                    cuerpo = cuerpo + " </coordinates></LineString> </Placemark> ";
                }

                // Se termina el bucle, generamos el fichero kml y lo abrimos
                cuerpo = cuerpo + " </Folder></Document></kml> ";
                encabezado = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + " <kml xmlns=\"http://www.opengis.net/kml/2.2\"> " + " " +
                    "<Document><name> " + elnombre + " </name> <open> 1 </open> " + iconos + "<Folder> <name> " + elnombre + " </name> <open> 1 </open> ";

                if (GeneraKML(encabezado + cuerpo, ruta))
                {
                    AbrirAchivo(ruta);
                }
                return;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return;
            }
        }
        private bool GeneraKML(string info, string LaRuta) // Buscamos que encuentre el archivo
        {
            try
            {
                StreamWriter sw = new StreamWriter(LaRuta, false, Encoding.UTF8);
                sw.WriteLine(info);
                sw.Close();
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
        public bool AbrirAchivo(string ruta) // Abrimos el archivo .kml
        {
            System.Diagnostics.Process.Start(ruta);
            return true;
        }

        public string GetModIcons()
        {
            // Cargamos todos los diferentes íconos que usaremos para que no nos salgan los comunes en Google Earth
            string iconos = "<Style id=\"default\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/I.png</href>" +
                        "</Icon><hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon><href>" +
                        "http://maps.google.com/mapfiles/kml/paddle/I-lv.png</href></ItemIcon></ListStyle></Style><StyleMap id=\"default0\"><Pair>" +
                        "<key>normal</key><styleUrl>#default2</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#hl0</styleUrl></Pair></StyleMap>" +
                        "<StyleMap id=\"default1\"><Pair><key>normal</key><styleUrl>#default</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#hl</styleUrl>" +
                        "</Pair></StyleMap><Style id=\"default2\"><LineStyle><color>ffffff55</color><width>3</width></LineStyle></Style><Style id=\"hl\">" +
                        "<IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/I.png</href></Icon><hotSpot x=\"32\" y=\"1\" xunits" +
                        "=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon><href>http://maps.google.com/mapfiles/kml/paddle/I-lv.png</href>" +
                        "</ItemIcon></ListStyle></Style><Style id=\"hl0\"><IconStyle><scale>1.2</scale></IconStyle><LineStyle><color>ffffff55</color><width>3</width>" +
                        "</LineStyle></Style><StyleMap id=\"msn_F\"><Pair><key>normal</key><styleUrl>#sn_F</styleUrl></Pair><Pair><key>highlight</key>" +
                        "<styleUrl>#sh_F</styleUrl></Pair></StyleMap><StyleMap id=\"msn_airports\"><Pair><key>normal</key><styleUrl>#sn_airports</styleUrl>" +
                        "</Pair><Pair><key>highlight</key><styleUrl>#sh_airports</styleUrl></Pair></StyleMap><StyleMap id=\"msn_airports0\"><Pair>" +
                        "<key>normal</key><styleUrl>#sn_airports0</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_airports0</styleUrl></Pair>" +
                        "</StyleMap><Style id=\"sh_F\"><IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/F.png</href></Icon>" +
                        "<hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon>" +
                        "<href>http://maps.google.com/mapfiles/kml/paddle/F-lv.png</href></ItemIcon></ListStyle></Style><Style id=\"sh_airports\"><IconStyle>" +
                        "<scale>1.4</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon><hotSpot x=\"0.5\" y=\"0\" xunits" +
                        "=\"fraction\" yunits=\"fraction\"/></IconStyle></Style><Style id=\"sh_airports0\"><IconStyle><scale>1.4</scale><Icon>" +
                        "<href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon><hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/>" +
                        "</IconStyle></Style><Style id=\"sn_F\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/F.png</href>" +
                        "</Icon><hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon>" +
                        "<href>http://maps.google.com/mapfiles/kml/paddle/F-lv.png</href></ItemIcon></ListStyle></Style><Style id=\"sn_airports\"><IconStyle>" +
                        "<scale>1.2</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon>" +
                        "<hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/></IconStyle></Style><Style id=\"sn_airports0\"><IconStyle>" +
                        "<scale>1.2</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon>" +
                        "<hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/></IconStyle></Style>";
            return iconos;
        }
    }
}
