using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Empleado : Persona
    {
        public double Sueldo { get; set; }
        public DateTime FechaContrato { get; set; }
        public List<VentaPaquete> VentasPaquetes { get; set; }

        public Empleado() : base()
        {
            VentasPaquetes = new List<VentaPaquete>();
        }
    }
}