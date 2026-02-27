using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repasoi1
{
    internal class Asistencia
    {
        int noEmpleado;
        decimal horasTrabajadas;
        int mes;

        public int NoEmpleado { get => noEmpleado; set => noEmpleado = value; }
        public decimal HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }
        public int Mes { get => mes; set => mes = value; }
    }
}
