using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.ModulodeSeguridad
{
    public class GrupoPermiso
    {
        private int grupoPermisoId;
        private int grupoId;
        private int permisoId;

        [Key]
        public int GrupoPermisoId
        {
            get { return grupoPermisoId; }
            set
            {
                if (value > 0)
                {
                    grupoPermisoId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del grupo permiso debe ser mayor a 0.");
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

        [ForeignKey("Permiso")]
        public int PermisoId
        {
            get { return permisoId; }
            set
            {
                if (value > 0)
                {
                    permisoId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del permiso debe ser mayor a 0.");
                }
            }
        }

        public GrupoPermiso()
        {
            grupoId = 0;
            permisoId = 0;
        }
    }
}
