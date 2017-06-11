using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class VentaPaquete
    {
        public int VentaPaqueteId { get; set; }
        public double MontoAPagar { get; set; }
        public List<Paquete> Paquetes { get; set; }
        public int MedioPagoId { get; set; }
        public MedioPago MedioPago { get; set; }
        public int ComprobantePagoId { get; set; }
        public ComprobantePago ComprobantePago { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }

        public VentaPaquete()
        {

        }

        public VentaPaquete(Empleado empleado, Cliente cliente)
        {
            Empleado = empleado;
            Cliente = cliente;
            Paquetes = new List<Paquete>();
            MedioPago = new MedioPago();
            ComprobantePago = new ComprobantePago();
        }
    }
}