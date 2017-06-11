using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public abstract class ServicioTuristico
    {
        public int ServicioTuristicoId { get; set; }
        public double PrecioServicioTuristico { get; set; }
        public List<Paquete> Paquetes { get; set; }

        public ServicioTuristico()
        {
            Paquetes = new List<Paquete>();
        }
    }
}