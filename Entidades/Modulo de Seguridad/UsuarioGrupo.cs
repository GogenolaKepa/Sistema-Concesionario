using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entidades.ModulodeSeguridad;

namespace Entidades.ModulodeSeguridad
{
    public class UsuarioGrupo
    {
        private int usuarioGrupoId;
        private int usuarioId;
        private int grupoId;
        public Grupo Grupo { get; set; }
        public Usuario Usuario { get; set; }


        [Key]
        public int UsuarioGrupoId
        {
            get { return usuarioGrupoId; }
            set
            {
                if (value > 0)
                {
                    usuarioGrupoId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del usuario grupo debe ser mayor a 0.");
                }
            }
        }

        [ForeignKey("Usuario")]
        public int UsuarioId
        {
            get { return usuarioId; }
            set
            {
                if (value > 0)
                {
                    usuarioId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del usuario debe ser mayor a 0.");
                }
            }
        }

        [ForeignKey("Grupo")]
        public int GrupoId
        {
            get { return grupoId; }
            set
            {
                if (value > 0)
                {
                    grupoId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del grupo debe ser mayor a 0.");
                }
            }
        }
        public UsuarioGrupo()
        {
            usuarioId = 0;
            grupoId = 0;
        }
    }
}
