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
    public partial class RecuperarContraseña : Form
    {
        DataTable dt;
        BD baseD;
        public RecuperarContraseña()
        {
            InitializeComponent();
        }

        private void botonRecuperar_Click(object sender, EventArgs e)
        {
            string correo = textBoxMail.Text;
            string contr = textBoxPassword.Text;
            string confCont = textBoxConfPaswrd.Text;
            if (correo == "" || contr == "")
            {
                labelInformacion.Text = "Missing boxes";
                labelInformacion.BackColor = Color.LightCoral;
                labelInformacion.Visible = true;
            }
            else
            {
                if (confCont != contr)
                {
                    labelInformacion.Text = "The passowrds must be the same";
                    labelInformacion.BackColor = Color.LightCoral;
                    labelInformacion.Visible = true;
                }
                else
                {
                    List<string> trozos = contr.Select(x => x.ToString()).ToList();
                    if (trozos.Count < 8)
                    {
                        labelInformacion.Text = "The password must be 8 characters long";
                        labelInformacion.BackColor = Color.LightCoral;
                        labelInformacion.Visible = true;
                    }
                    else
                    {
                        bool comillas = false;
                        foreach (string c in trozos)
                        {
                            if (c == "'")
                            {
                                comillas = true;
                                labelInformacion.Text = "You can not use ' in your password";
                                labelInformacion.BackColor = Color.LightCoral;
                                labelInformacion.Visible = true;
                            }
                        }
                        if (comillas == false)
                        { 
                            baseD.Iniciar();
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.Credentials = new NetworkCredential("trabajosuniadrianupc@gmail.com", "aiaj lzrt weme wpsk");
                            smtp.EnableSsl = true;
                            MailMessage mensaje = new MailMessage();
                            mensaje.From = new MailAddress("trabajosuniadrianupc@gmail.com");
                            mensaje.To.Add(correo);
                            mensaje.Subject = "Your password has been restablished";
                            mensaje.Body = "The password has been restablished, if it wasn't you, respond to this email. Someone from our staff will contact with you";
                            mensaje.IsBodyHtml = false; // Cambia a true si quieres enviar HTML
                            smtp.Send(mensaje);

                            baseD.ModificarContraseña(contr, correo);
                            baseD.Cerrar();
                            labelInformacion.Text = "Password changed successfully";
                            labelInformacion.BackColor = Color.LightCoral;
                            labelInformacion.Visible = true;
                            timerCerrar.Interval = 2500;
                            timerCerrar.Start();

                        }
                    }
                }
            }
        }

        private void RecuperarContraseña_Load(object sender, EventArgs e)
        {
            baseD = new BD();
            baseD.Iniciar();
            dt = baseD.GetUsers();
            baseD.Cerrar();
        }

        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
