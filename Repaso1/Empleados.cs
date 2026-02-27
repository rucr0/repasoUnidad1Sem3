using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repasoi1
{
    internal class Empleados
    {
        int noEmpleado;
        string nombre;
        string apellido;
        decimal suedoHora;

        public int NoEmpleado { get => noEmpleado; set => noEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public decimal SuedoHora { get => suedoHora; set => suedoHora = value; }
    }
}
