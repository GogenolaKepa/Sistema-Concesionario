using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class DetalleCompra
    {
        private int detalleCompraId;
        private int ordenCompraId;
        private int vehiculoId;
        private int cantidad;
        private decimal precioUnitario;

        [Key]
        public int DetalleCompraId
        {
            get { return detalleCompraId; }
            set { detalleCompraId = value; }
        }

        public int OrdenCompraId
        {
            get { return ordenCompraId; }
            set { ordenCompraId = value; }
        }

        public OrdenCompra OrdenCompra { get; set; }

        public int VehiculoId
        {
            get { return vehiculoId; }
            set { vehiculoId = value; }
        }

        public Vehiculo Vehiculo { get; set; }

        [Required]
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("La cantidad debe ser mayor a 0.");
                cantidad = value;
            }
        }

        [Required]
        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("El precio unitario debe ser mayor a 0.");
                precioUnitario = value;
            }
        }
    }
}
