using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class CategoriaHospedaje
    {
        public int CategoriaHospedajeId { get; set; }
        public string NomCategoriaHospedaje { get; set; }
        public List<Hospedaje> Hospedajes { get; set; }

        public CategoriaHospedaje()
        {
            Hospedajes = new List<Hospedaje>();
        }
    }
}