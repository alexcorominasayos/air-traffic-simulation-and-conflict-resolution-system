using BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Main_Menu
{
    public partial class LogInMenu : Form
    {
        DataTable tablaDatos;

        public LogInMenu()
        {
            InitializeComponent();
        }

        private void MenuContraseña_Load(object sender, EventArgs e)
        {
            //Estetica
            labelContraseña.BackColor = Color.Transparent;
            LabelUser.BackColor = Color.Transparent;
            labelTitulo.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            textBoxPassword.PasswordChar = '•';

            //Base de datos 
            try
            {
                BD baseUsuarios = new BD();
                baseUsuarios.Iniciar();
                tablaDatos = baseUsuarios.GetUsers();
                baseUsuarios.Cerrar();
            }
            catch (SQLiteException)
            { 
                MessageBox.Show("DATA BASE CAN NOT BE LOADED");
                Close();
            }
        }

        private void botonIniciarSesion_Click(object sender, EventArgs e)
        {
            bool autenticar = false;
            string usuario = textBoxUser.Text;
            string contraseña = textBoxPassword.Text;
            foreach(DataRow fila in tablaDatos.Rows)
            {
                string usuarioDatos = fila["nombre"].ToString();
                string contraseñaDatos = fila["contraseña"].ToString();
                if (usuario ==  usuarioDatos && contraseña == contraseñaDatos)
                {
                    autenticar = true;
                }
            }
            if (autenticar)
            {
                Form1 menu = new Form1();
                menu.SetUsuario(usuario);
                textBoxPassword.Text = "";
                textBoxUser.Text = "";
                menu.Show();
                this.Hide();
            }

            else
            {
                labelInformacion.Text = "   \n   User not found or wrong password   \n ";
                labelInformacion.BackColor = Color.LightCoral;
                labelInformacion.Visible = true;
            }
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUser ru = new RegistrarUser();
            ru.ShowDialog();
            BD baseUsiarios = new BD();
            baseUsiarios.Iniciar();
            tablaDatos = baseUsiarios.GetUsers();
            baseUsiarios.Cerrar();
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botonOlvCont_Click(object sender, EventArgs e)
        {
            PasswordRecoveryMenu rc = new PasswordRecoveryMenu();
            rc.ShowDialog();
            BD baseUsiarios = new BD();
            baseUsiarios.Iniciar();
            tablaDatos = baseUsiarios.GetUsers();
            baseUsiarios.Cerrar();
        }
    }
}
