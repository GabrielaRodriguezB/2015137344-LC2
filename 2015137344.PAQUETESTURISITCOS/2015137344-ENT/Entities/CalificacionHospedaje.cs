using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class CalificacionHospedaje
    {
        public int CalificacionHospedajeId { get; set; }
        public string Calificacion { get; set; }
        public List<Hospedaje> Hospedajes { get; set; }

        public CalificacionHospedaje()
        {
            Hospedajes = new List<Hospedaje>();
        }
    }
}