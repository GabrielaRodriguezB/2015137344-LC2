using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class ComprobantePago
    {
        public int ComprobantePagoId { get; set; }
        public int NumComprobantePago { get; set; }
        public int TipoComprobanteId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public int VentaPaqueteId { get; set; }
        public VentaPaquete VentaPaquete { get; set; }

        public ComprobantePago()
        {
            TipoComprobante = new TipoComprobante();
            VentaPaquete = new VentaPaquete();
        }
    }
}