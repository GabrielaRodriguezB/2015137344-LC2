using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class TipoTransporte
    {
        public int TipoTransporteId { get; set; }
        public string NomTipoTransporte { get; set; }
        public List<Transporte> Transportes { get; set; }

        public TipoTransporte()
        {
            Transportes = new List<Transporte>();
        }
    }
}