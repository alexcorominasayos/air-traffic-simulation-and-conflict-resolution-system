using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class CurrentDataMenu : Form
    {
        public FlightPlanList ListaGridData { get; set; }
        public CurrentDataMenu()
        {
            InitializeComponent();
        }

        //Muestra la distancia con los otros aviones al clicar encima del id
        private void fpdataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)        
        {
            int fila = e.RowIndex;
            int column = e.ColumnIndex;
            int i = 1;
            if (column == 0 && fila > 0)
            {
                while (i <= ListaGridData.GetNum())
                {
                    double distancia = ListaGridData.GetFlightPlan(fila-1).GetCurrentPosition().Distancia(ListaGridData.GetFlightPlan(i-1).GetCurrentPosition());
                    fpdataGrid.Rows[i].Cells[4].Value = Math.Round(distancia,2);
                    i++;
                }
                i = 0;
            }
            else
                MessageBox.Show("Click an ID to view the distances between aircrafts");  //Si se clica dnd no es sale esta message box
        }

        //carga el grid con los datos de los aviones
        private void CurrentDataMenu_Load(object sender, EventArgs e)          
        {
            fpdataGrid.ColumnCount = 5;
            fpdataGrid.RowCount = ListaGridData.GetNum()+1;
            fpdataGrid.ColumnHeadersVisible = false;
            fpdataGrid.RowHeadersVisible = false;
            fpdataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            fpdataGrid.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;
            fpdataGrid.Rows[0].Cells[0].Value = "ID";
            fpdataGrid.Rows[0].Cells[1].Value = "X";
            fpdataGrid.Rows[0].Cells[2].Value = "Y";
            fpdataGrid.Rows[0].Cells[3].Value = "Velocity";
            fpdataGrid.Rows[0].Cells[4].Value = "Distances";
            int i = 1;
            while (i <= ListaGridData.GetNum())
            {
                fpdataGrid.Rows[i].Cells[0].Value = ListaGridData.GetFlightPlan(i - 1).getId();
                fpdataGrid.Rows[i].Cells[1].Value = Math.Round(ListaGridData.GetFlightPlan(i - 1).GetCurrentPosition().GetX(), 2);
                fpdataGrid.Rows[i].Cells[2].Value = Math.Round(ListaGridData.GetFlightPlan(i - 1).GetCurrentPosition().GetY(), 2);
                fpdataGrid.Rows[i].Cells[3].Value = Math.Round(ListaGridData.GetFlightPlan(i - 1).GetVelocidad(),2);
                fpdataGrid.Rows[i].Cells[4].Value = "-";
                i++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
