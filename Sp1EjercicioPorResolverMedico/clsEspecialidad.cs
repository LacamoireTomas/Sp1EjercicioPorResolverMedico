using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sp1EjercicioPorResolverMedico
{
    internal class clsEspecialidad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public void Grabar(string txtID, string txtNombre)
        {
            if (txtID == "" || txtNombre == "")
            {
                MessageBox.Show("Faltan datos por completar!", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ID = int.Parse(txtID);
                Nombre = txtNombre;

            }

            string linea;

            using (StreamReader Lectorcito = new StreamReader("ESPECIALIDADES.TXT"))
            {
                while (Lectorcito.EndOfStream == false)
                {
                    linea = Lectorcito.ReadLine();

                    if (ID == int.Parse(linea.Split(',')[0]))
                    {
                        MessageBox.Show("Ya existe una especialidad con ese ID", "Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }

            }

            using (StreamWriter streamWriter = new StreamWriter("ESPECIALIDADES.txt", true))
            {
                streamWriter.WriteLine(ID + "," + Nombre);
                txtID = "";
                txtNombre = "";
                MessageBox.Show("Especialidad " + Nombre + " registrada correctamente", "Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        public void CargarEspecialidad(ComboBox cmbEspecialidad)
        {
            string auxiliar;
            using (StreamReader streamReader = new StreamReader("ESPECIALIDADES.txt"))
            {
                while (streamReader.EndOfStream == false)
                {
                    auxiliar = streamReader.ReadLine();
                    Nombre = auxiliar.Split(',')[1];

                    cmbEspecialidad.Items.Add(Nombre);

                }
            }

           
        }

    }
}
