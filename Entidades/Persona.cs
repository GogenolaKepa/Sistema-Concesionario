using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ModulodeSeguridad;

namespace Entidades
{
    public class Persona
    {
        private int personaId;
        private Usuario usuario;

        public int PersonaId
        {
            get { return personaId; }
            set { personaId = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
