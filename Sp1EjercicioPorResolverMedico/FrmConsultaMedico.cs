using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sp1EjercicioPorResolverMedico
{
    public partial class FrmConsultaMedico : Form
    {
        public FrmConsultaMedico()
        {
            InitializeComponent();
        }

        private void FrmConsultaMedico_Load(object sender, EventArgs e)
        {
            clsEspecialidades objEspecialidad = new clsEspecialidades();
            
            clsMedico objMedico = new clsMedico();
            objMedico.ListarMedicos(dgvConsultas, cmbEspecialidad);
        }

        private void btnRegistrarEspecialidad_Click(object sender, EventArgs e)
        {
            frmEspecialidades frm = new frmEspecialidades();
            frm.ShowDialog();
        }

        private void btnRegistrarMedico_Click(object sender, EventArgs e)
        {
            frmMedicos frm = new frmMedicos();
            frm.ShowDialog();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsMedico objMedico = new clsMedico();
            objMedico.ListarMedicos(dgvConsultas, cmbEspecialidad);
        }
    }
}
