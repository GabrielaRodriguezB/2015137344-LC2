using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public class Cliente : Persona
    {
        public string Correo { get; set; }
        public List<VentaPaquete> VentasPaquetes { get; set; }

        public Cliente() : base()
        {
            VentasPaquetes = new List<VentaPaquete>();
        }
    }
}