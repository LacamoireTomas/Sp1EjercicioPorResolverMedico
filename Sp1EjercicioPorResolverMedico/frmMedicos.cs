using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp1EjercicioPorResolverMedico
{
    public partial class frmMedicos : Form
    {
        public frmMedicos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clsMedico objMedico = new clsMedico();
            objMedico.Grabar(txtMatricula, txtNombre, cmbEspecialidad);
            
        }

        private void frmMedicos_Load(object sender, EventArgs e)
        {
            clsEspecialidad objEspecialidad = new clsEspecialidad();
            objEspecialidad.CargarEspecialidad(cmbEspecialidad);

        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
