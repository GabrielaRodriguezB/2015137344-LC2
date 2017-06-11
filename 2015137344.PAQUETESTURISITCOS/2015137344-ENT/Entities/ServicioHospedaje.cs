using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class ServicioHospedaje
    {
        public int ServicioHospedajeId { get; set; }
        public string NomServicioHospedaje { get; set; }
        public List<Hospedaje> Hospedajes { get; set; }

        public ServicioHospedaje()
        {
            Hospedajes = new List<Hospedaje>();
        }
    }
}