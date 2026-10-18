using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace BaseDatos
{
    public class BD
    {
        private SQLiteConnection cnx;
        private SQLiteCommand cmd;

        public void Iniciar ()
        {
            
            // string baseDatos = "Data Source= C:\\Users\\user\\Desktop\\Project Info 2\\prgramas de la base de datos\\BD.db";  //Direccion base datos !!!!!!!ADRIAN!!!!
            string baseDatos = "Data Source= BD.db";
            cnx = new SQLiteConnection(baseDatos);
            cnx.Open();
           
        }

        public void Cerrar()
        {   cnx.Close ();   }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable ();
            string sql = "SELECT * FROM usersV2";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill (dt);
            return dt;
        }

        public DataTable GetCompañias()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM compsV2";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        public int ContUsers(DataTable dt)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            { i = i + 1;}
            return i;
        }

        public void añadirUser(string usuario, string contraseña, string correo, DataTable dt)
        {
            string sqlInsert = "INSERT INTO usersV2 (nombre, contraseña, correo, id) VALUES (@nombre, @contraseña, @correo, @id);";
            cmd = new SQLiteCommand(sqlInsert, cnx);
            cmd.Parameters.AddWithValue("@nombre", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@correo", correo);
            int id = ContUsers(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string idDatos = dr["id"].ToString();
                if (Convert.ToString(id) == idDatos)
                {
                    id = id + 1;
                }
            }
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
        }

        public void ModificarContraseña(string nuevaC, string correo)
        {
            string sqlInsert = "UPDATE usersV2 SET contraseña=@contraseña WHERE correo=@correo";
            cmd = new SQLiteCommand(sqlInsert,cnx);
            cmd.Parameters.AddWithValue("@contraseña", nuevaC);
            cmd.Parameters.AddWithValue("@correo",correo);
            cmd.ExecuteNonQuery();
        }

        public void AñadirComp(string nombre, string id, int telefono, string correo, string photo, string cadenaConexion)
        {
            try
            {
                if (File.Exists(photo))  // Verificar si el archivo existe
                {
                    byte[] fotoBytes = File.ReadAllBytes(photo);

                    using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "INSERT INTO compsV2 (Name, Identificator, Phone, Email, Logo) VALUES (@nombre, @ID, @telefono, @correo, @logo)";

                        using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@nombre", nombre);
                            comando.Parameters.AddWithValue("@ID", id);
                            comando.Parameters.AddWithValue("@telefono", telefono);
                            comando.Parameters.AddWithValue("@correo", correo);
                            comando.Parameters.Add("@logo", DbType.Binary).Value = fotoBytes;  // Asegurarse de que esto es un array de bytes

                            comando.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void BorrarComp(string nombre)
        {
            string cadenaConexion = "Data Source=BD.db"; 

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para eliminar la fila con el ID dado
                string consulta = "DELETE FROM compsV2 WHERE Name = @nombre";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
