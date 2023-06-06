using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sp1EjercicioPorResolverMedico
{
    internal class clsMedico
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }


        public void ConsultarMedicos(DataGridView dgvConsultas, ComboBox cmbEspecialidad)
        {

            dgvConsultas.Rows.Clear();

            string linea;
            string especialidad = "";
            int idEspecialidad = 0;
            string auxEsp;

            using (StreamReader Lectorcito = new StreamReader("MEDICOS.txt"))
            {

                while (Lectorcito.EndOfStream == false)
                {
                    linea = Lectorcito.ReadLine();
                    if (cmbEspecialidad.Text == "Todas")
                    {
                        using (StreamReader streamReaderE = new StreamReader("ESPECIALIDADES.txt"))
                        {
                            while (streamReaderE.EndOfStream == false)
                            {
                                auxEsp = streamReaderE.ReadLine();
                                if (linea.Split(',')[2] == auxEsp.Split(',')[0])
                                {
                                    especialidad = auxEsp.Split(',')[1];
                                }
                            }
                            dgvConsultas.Rows.Add(linea.Split(',')[0], linea.Split(',')[1], especialidad);

                        }
                    }
                    else
                    {
                        using (StreamReader streamReaderE = new StreamReader("ESPECIALIDADES.txt"))
                        {
                            while (streamReaderE.EndOfStream == false)
                            {
                                auxEsp = streamReaderE.ReadLine();
                                if (cmbEspecialidad.Text == auxEsp.Split(',')[1])
                                {
                                    idEspecialidad = int.Parse(auxEsp.Split(',')[0]);
                                }
                            }
                            if (int.Parse(linea.Split(',')[2]) == idEspecialidad)
                            {
                                dgvConsultas.Rows.Add(linea.Split(',')[0], linea.Split(',')[1], cmbEspecialidad.Text);
                            }

                        }

                    }
                }

            }


        }

        public void Grabar(TextBox txtMatricula, TextBox txtNombre, ComboBox cmbEspecialidad)
        {
            if (txtMatricula.Text != "" && txtNombre.Text != "" && cmbEspecialidad.SelectedIndex != -1)
            {
                string auxiliar;
                using (StreamReader streamReader = new StreamReader("MEDICOS.txt"))
                {
                    while (streamReader.EndOfStream == false)
                    {
                        auxiliar = streamReader.ReadLine();
                        if (auxiliar.Split(',')[0] == txtMatricula.Text)
                        {
                            MessageBox.Show("El médico ingresado ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                int idEspecialidad = 0;

                using (StreamReader streamReaderE = new StreamReader("ESPECIALIDADES.txt"))
                {
                    while (streamReaderE.EndOfStream == false)
                    {
                        auxiliar = streamReaderE.ReadLine();
                        if (cmbEspecialidad.Text == auxiliar.Split(',')[1])
                        {
                            idEspecialidad = int.Parse(auxiliar.Split(',')[0]);
                        }
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("MEDICOS.txt", true))
                {
                    streamWriter.Write(txtMatricula.Text + "," + txtNombre.Text + "," + idEspecialidad.ToString() + "\n");
                    MessageBox.Show("Médico " + txtNombre.Text + " registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatricula.Text = "";
                    txtNombre.Text = "";
                    cmbEspecialidad.SelectedIndex = -1;

                }
            }
            else
            {
                MessageBox.Show("Faltan datos por ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }







        }


    }

}
