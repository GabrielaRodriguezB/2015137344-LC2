using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class TipoComprobante
    {
        public int TipoComprobanteId { get; set; }
        public string NomTipoComprobante { get; set; }
        public List<ComprobantePago> ComprobantesPago { get; set; }

        public TipoComprobante()
        {
            ComprobantesPago = new List<ComprobantePago>();
        }
    }
}