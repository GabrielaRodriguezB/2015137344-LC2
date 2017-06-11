using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Paquete
    {
        public int PaqueteId { get; set; }
        public string NomPaquete { get; set; }
        public double PrecioPaquete { get; set; }
        public List<ServicioTuristico> ServiciosTuristicos { get; set; }
        public List<VentaPaquete> VentasPaquetes { get; set; }

        public Paquete()
        {
            ServiciosTuristicos = new List<ServicioTuristico>();
            VentasPaquetes = new List<VentaPaquete>();
        }
    }
}