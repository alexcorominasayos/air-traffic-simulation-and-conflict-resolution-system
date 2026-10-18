using BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class RegistrarUser : Form
    {
        DataTable tablaDatos;
        BD datos;

        public RegistrarUser()
        {
            InitializeComponent();
        }
        
        private void RegistrarUser_Load(object sender, EventArgs e)
        {
            datos = new BD();
            datos.Iniciar();
            tablaDatos = datos.GetUsers();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool mismoUser = false;
            string nombre = textBoxUser.Text;
            string contraseña = textBoxPassword.Text;
            string confcont = textBoxConfPaswrd.Text;
            string correo = textBoxMail.Text;

            if (nombre == "" || contraseña == "" || correo =="")
            {
                labelInformacion.Text = "Missing boxes";
                labelInformacion.BackColor = Color.LightCoral;
                labelInformacion.Visible = true;
            }
            else
            {
                foreach (DataRow row in tablaDatos.Rows)
                {
                    if (nombre == Convert.ToString(row["nombre"]))
                    {
                        labelInformacion.Text = "This username is already used";
                        labelInformacion.BackColor = Color.LightCoral;
                        labelInformacion.Visible = true;
                        mismoUser = true;
                    }
                }
                if (mismoUser == false)
                {
                    if (confcont != contraseña)
                    {
                        labelInformacion.Text = "The passwords must be the same";
                        labelInformacion.BackColor = Color.LightCoral;
                        labelInformacion.Visible = true;
                    }
                    else
                    {
                        List<string> trozos = contraseña.Select(x => x.ToString()).ToList();
                        if (trozos.Count < 8)
                        {
                            labelInformacion.Text = "The password must be 8 characters long";
                            labelInformacion.BackColor = Color.LightCoral;
                            labelInformacion.Visible = true;
                        }
                        else
                        {
                            bool comillas = false;
                            foreach (string t in trozos)
                            {
                                if (t == "'")
                                    comillas = true;
                                labelInformacion.Text = "You can not use ' in your password";
                                labelInformacion.BackColor = Color.LightCoral;
                                labelInformacion.Visible = true;
                            }
                            if (comillas == false)
                            {
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.Credentials = new NetworkCredential("trabajosuniadrianupc@gmail.com", "aiaj lzrt weme wpsk");
                                smtp.EnableSsl = true;
                                MailMessage mensaje = new MailMessage();
                                mensaje.From = new MailAddress("trabajosuniadrianupc@gmail.com");
                                mensaje.To.Add(correo);
                                mensaje.Subject = "A new account has been created";
                                mensaje.Body = "A new account to the Conflict Solver has been created using this mail, if it wasn't you, respond to this email.";
                                mensaje.IsBodyHtml = false;
                                smtp.Send(mensaje);

                                datos.añadirUser(nombre, contraseña, correo, tablaDatos);
                                buttonRegister.Visible = false;
                                labelInformacion.Text = "User registered successfully";
                                labelInformacion.BackColor = Color.PaleGreen;
                                labelInformacion.Visible = true;
                                datos.Cerrar();
                                timerUserReg.Interval = 2500;
                                timerUserReg.Start();
                            }
                        }
                    }
                }
            }
        } 
        private void timerUserReg_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
