using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class TipoHospedaje
    {
        public int TipoHospedajeId { get; set; }
        public string NomTipoHospedaje { get; set; }
        public List<Hospedaje> Hospedajes { get; set; }

        public TipoHospedaje()
        {
            Hospedajes = new List<Hospedaje>();
        }
    }
}