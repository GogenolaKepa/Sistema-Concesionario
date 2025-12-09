using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.ModulodeSeguridad
{
    public class Permiso
    {
        private int permisoId;
        private string nombrePermiso;
        private string descripcion;

        [Key]
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

        [Required]
        [MaxLength(100)]
        public string NombrePermiso
        {
            get { return nombrePermiso; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nombrePermiso = value;
                }
                else
                {
                    throw new ArgumentException("El nombre del permiso no puede estar vacío.");
                }
            }
        }

        [MaxLength(250)]
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value ?? "Sin descripción";
            }
        }

        public Permiso()
        {
            nombrePermiso = string.Empty;
            descripcion = "Sin descripción";
        }
    }
}
