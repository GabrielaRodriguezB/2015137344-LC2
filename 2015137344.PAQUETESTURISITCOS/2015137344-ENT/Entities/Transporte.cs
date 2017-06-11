using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Transporte : ServicioTuristico
    {
        public string NomEmpresaTransporte { get; set; }
        public int TipoTransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public int CategoriaTransporteId { get; set; }
        public CategoriaTransporte CategoriaTransporte { get; set; }

        public Transporte() : base()
        {
            TipoTransporte = new TipoTransporte();
            CategoriaTransporte = new CategoriaTransporte();
        }
    }
}