using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Alimentacion : ServicioTuristico
    {
        public string NomEstablecimiento { get; set; }
        public int CategoriaAlimentacionId { get; set; }
        public CategoriaAlimentacion CategoriaAlimentacion { get; set; }

        public Alimentacion() : base()
        {
            CategoriaAlimentacion = new CategoriaAlimentacion();
        }
    }
}
