using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class MedioPago
    {
        public int MedioPagoId { get; set; }
        public string NomMedioPago { get; set; }
        public List<VentaPaquete> VentasPaquetes { get; set; }

        public MedioPago()
        {
            VentasPaquetes = new List<VentaPaquete>();
        }
    }
}