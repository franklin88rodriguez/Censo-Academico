using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaAcademica.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      public void button1_Click(object sender, EventArgs e)
        {
            var Asingatura = new CargaAcademicaBL();

            //var ListaAsignaturas = Asingatura.ObtenerAsignaturas();

            //foreach (var Asignatura in ListaAsignaturas)
            //{
            //    MessageBox.Show(Asignatura.Seccion);
            //}

        }
    }
}
