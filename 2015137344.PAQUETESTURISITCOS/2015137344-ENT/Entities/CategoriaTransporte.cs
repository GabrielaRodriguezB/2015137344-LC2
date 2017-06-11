using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class CategoriaTransporte
    {
        public int CategoriaTransporteId { get; set; }
        public string NomCategoriaTransporte { get; set; }
        public List<Transporte> Transportes { get; set; }

        public CategoriaTransporte()
        {
            Transportes = new List<Transporte>();
        }
    }
}