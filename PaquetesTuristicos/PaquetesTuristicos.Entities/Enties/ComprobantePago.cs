using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class ComprobantePago
    {
        public int ComprobantePagoId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        
        public ComprobantePago()
        {
            TipoComprobante = new TipoComprobante();
        }
    }
}
