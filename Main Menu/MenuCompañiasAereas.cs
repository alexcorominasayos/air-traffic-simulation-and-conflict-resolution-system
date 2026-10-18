using BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class MenuCompañiasAereas : Form
    {
        DataTable dt;

        public MenuCompañiasAereas()
        {
            InitializeComponent();
        }

        public byte[] ConvertHexToBytes(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void MenuCompañiasAereas_Load(object sender, EventArgs e)
        {
            this.Width = 1121;
            this.Height = 796;
            dataGridView1.Width = 1075;
            dataGridView1.Height = 615;

            dataGridView1.AllowUserToAddRows = false;
            BD comp = new BD();
            comp.Iniciar();
            dt = comp.GetCompañias();
            comp.Cerrar();

            dataGridView1.DataSource = dt;
            CargarImagenesEnDataGridView();
        }

        public void CargarImagenesEnDataGridView()
        {
            // Configurar la columna como columna de imágenes
            if (dataGridView1.Columns[4] is DataGridViewImageColumn == false)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                {
                    ImageLayout = DataGridViewImageCellLayout.Zoom, // Las imágenes se ajustarán al tamaño de la celda
                    HeaderText = "Foto"
                };
                dataGridView1.Columns.RemoveAt(4); // Elimina la columna existente
                dataGridView1.Columns.Insert(4, imageColumn); // Inserta la nueva columna
            }

            // Cargar las imágenes en las celdas
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != DBNull.Value && row.Cells[4].Value != null)
                {
                    byte[] imageData = row.Cells[4].Value as byte[];

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            try
                            {
                                Image img = Image.FromStream(ms);
                                // Redimensionar la imagen
                                Image resizedImage = ResizeImage(img, 200, 600); // Cambia estas dimensiones
                                row.Cells[4].Value = resizedImage;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                            }
                        }
                    }
                }
            }

            // Ajustar la altura de las filas y el ancho de la columna
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 200; // Cambia este valor según el alto que desees
            }
            dataGridView1.Columns[4].Width = 600; // Cambia este valor según el ancho que desees
            dataGridView1.Refresh();
        }

        private Image ResizeImage(Image image, int height, int width)
        {
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedBitmap;
        }


        private void botonAñadir_Click(object sender, EventArgs e)
        {
            AñadirComp ac = new AñadirComp();
            ac.ShowDialog();
        }

        private void botonborrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow filaSel = dataGridView1.SelectedRows[0];
                string nombre = filaSel.Cells["Name"].Value.ToString();
                BD comp = new BD();
                comp.Iniciar();
                dt = comp.GetCompañias();
                comp.BorrarComp(nombre);
                MessageBox.Show("Company deleted successfully");
                comp.Cerrar();
            }
            else
            {
                MessageBox.Show("Choose a row to delete its company");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                string texto = dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(texto))
                {
                    string url = $"https://www.google.com/search?q={Uri.EscapeDataString(texto)}";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
