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
using System.Diagnostics.Eventing.Reader;

namespace Repasoi1
{
    public partial class Form1 : Form
    {
        List <Empleados> empleado2 = new List<Empleados>();
        List<Asistencia> asistencia2 = new List<Asistencia>();
        List<Reporte> reporte2 = new List<Reporte>();
        public Form1()
        {
            InitializeComponent();
        }
       

        
        private void LeerAsistencia()
        {
            string fileName = @"C:\Users\hp\Desktop\UMES 2025\3 semestre ing\Progra III\Repaso1\Asistencia.txt";

            if (File.Exists(fileName))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {

                    Asistencia asistencia = new Asistencia();
                    asistencia.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                    asistencia.HorasTrabajadas = Convert.ToDecimal(reader.ReadLine());
                    asistencia.Mes = Convert.ToInt16(reader.ReadLine());
                    asistencia2.Add(asistencia);

                }

                reader.Close();


            }
        }

        private void Leer()
        {
            // Abre el archivo para leer
            string fileName = @"C:\Users\Owner\Desktop\Repaso1\bin\Debug\arch.txt";

            if (File.Exists(fileName)) { 
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            
                while (reader.Peek() > -1)
                {

                    // Lee cada línea del archivo y asigna los valores a las propiedades del objeto Empleados
                    Empleados empleado = new Empleados();
                    empleado.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                    empleado.Nombre = reader.ReadLine();
                    empleado.Apellido = reader.ReadLine();
                    empleado.SuedoHora = Convert.ToDecimal(reader.ReadLine());

                    empleado2.Add(empleado);
                }

                    reader.Close();
                
                
            }
        }

        private void GuardadEmpleados()
        {

            // Abre el archivo para escribir (crea el archivo si no existe)
            FileStream Stream = new FileStream(@"C:\Users\Owner\Desktop\Repaso1\bin\Debug\arch.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(Stream);
            foreach (var empleado in empleado2)
            {
                writer.WriteLine(empleado.NoEmpleado);
                writer.WriteLine(empleado.Nombre);
                writer.WriteLine(empleado.Apellido);
                writer.WriteLine(empleado.SuedoHora);

            }
            writer.Close();

        }

        private DataGridView GetDataGridView11()
        {
            return dataGridView1;
        }

        private void mostrar(DataGridView dataGridView11)
        {
            dataGridView1 = null;
            dataGridView11.DataSource = empleado2;

            dataGridViewAsistencias.DataSource = null;
            dataGridViewAsistencias.DataSource = asistencia2;


            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reporte2;

            
        }


        private void buttonIngresarEmpleados_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.NoEmpleado = Convert.ToInt16(numericUpDownNoEmpleado.Text);
            empleado.Nombre = textBoxNombre.Text;
            empleado.Apellido = textBoxApellido.Text;
            empleado.SuedoHora = numericUpDownSueldoHora.Value;

            empleado2.Add(empleado);

            GuardadEmpleados();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leer();
            LeerAsistencia();
            mostrar(GetDataGridView11());
            numericUpDownNoEmpleado.Value = empleado2.Count + 1;// Asigna el número de empleado automáticamente al cargar el formulario
            


        }

        private void buttonGenerar_Reporte_Click(object sender, EventArgs e)
        {
            foreach(var empleado in empleado2)
            {
                foreach(var asistencia in asistencia2)
                {
                    if(empleado.NoEmpleado == asistencia.NoEmpleado)
                    {
                        Reporte reporte = new Reporte();
                        reporte.Nombre = empleado.Nombre;
                        reporte.Apellido = empleado.Apellido;
                        reporte.SueldoMes = empleado.SuedoHora * asistencia.HorasTrabajadas;
                        reporte.Mes = asistencia.Mes;

                        reporte2.Add(reporte);

                    }
                }
            }
            mostrar(GetDataGridView11());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
