using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class VentaPaquete
    {
        public int VentaPaqueteId { get; set; }
        public Paquete Paquete { get; set; }
        public MedioPago MedioPago { get; set; }
        public ComprobantePago Comprobante { get; set; }

        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }

        
        public VentaPaquete()
        {
            Paquete = new Paquete();
            MedioPago = new MedioPago();
            Comprobante = new ComprobantePago();
        }

        public VentaPaquete(Empleado empleado, Cliente cliente)
        {
            Empleado = empleado;
            Cliente = cliente;

            Paquete = new Paquete();
            MedioPago = new MedioPago();
            Comprobante = new ComprobantePago();
        }
    }
}
