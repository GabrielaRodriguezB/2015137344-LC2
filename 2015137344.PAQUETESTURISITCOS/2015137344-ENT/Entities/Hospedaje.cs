using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Hospedaje : ServicioTuristico
    {
        public string NomHospedaje { get; set; }
        public int TipoHospedajeId { get; set; }
        public TipoHospedaje TipoHospedaje { get; set; }
        public int CalificacionHospedajeId { get; set; }
        public CalificacionHospedaje CalificacionHospedaje { get; set; }
        public int CategoriaHospedajeId { get; set; }
        public CategoriaHospedaje CategoriaHospedaje { get; set; }
        public List<ServicioHospedaje> ServiciosHospedaje { get; set; }

        public Hospedaje() : base()
        {
            TipoHospedaje = new TipoHospedaje();
            CalificacionHospedaje = new CalificacionHospedaje();
            CategoriaHospedaje = new CategoriaHospedaje();
            ServiciosHospedaje = new List<ServicioHospedaje>();
        }
    }
}