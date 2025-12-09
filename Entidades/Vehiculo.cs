using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Vehiculo
    {
        private int vehiculoId;
        private string marca;
        private string modelo;
        private int anio;
        private decimal precio;
        private bool disponibilidad;
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        private int cantidadDisponible;
        public int? InventarioId { get; set; }

        public int CantidadDisponible
        {
            get { return cantidadDisponible; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("La cantidad disponible no puede ser negativa.");
                cantidadDisponible = value;
            }
        }

        [Key]
        public int VehiculoId
        {
            get { return vehiculoId; }
            set { vehiculoId = value; }
        }

        [Required(ErrorMessage = "La marca del vehículo es obligatoria.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La marca debe tener entre 2 y 50 caracteres.")]
        public string Marca
        {
            get { return marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía.");
                marca = value;
            }
        }

        [Required(ErrorMessage = "El modelo del vehículo es obligatorio.")]
        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El modelo no puede estar vacío.");
                modelo = value;
            }
        }

        [Required(ErrorMessage = "El año del vehículo es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
        public int Anio
        {
            get { return anio; }
            set
            {
                if (value < 1900 || value > DateTime.Now.Year + 1)
                    throw new ArgumentOutOfRangeException("El año del vehículo no es válido.");
                anio = value;
            }
        }

        [Required(ErrorMessage = "El precio del vehículo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor a 0.");
                precio = value;
            }
        }

        public bool Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
    }
}
