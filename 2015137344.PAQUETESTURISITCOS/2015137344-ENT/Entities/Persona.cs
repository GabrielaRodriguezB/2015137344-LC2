using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_ENT.Entities
{
    public abstract class Persona
    {
        public int PersonaId { get; set; }
        public int DocIdPersona { get; set; }
        public string NomPersona { get; set; }
        public string ApePatPersona { get; set; }
        public string ApeMatPersona { get; set; }
    }
}
