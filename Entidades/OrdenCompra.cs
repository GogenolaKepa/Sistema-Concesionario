using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class OrdenCompra
    {
        private int ordenCompraId;
        private int proveedorId;
        private string fechaPedido;
        private int estadoOrdenCompraId;
        private decimal montoTotal;
        private List<DetalleCompra> detallesCompra;

        public List<DetalleCompra> DetallesCompra
        {
            get { return detallesCompra ?? new List<DetalleCompra>(); }
            set { detallesCompra = value ?? new List<DetalleCompra>(); }
        }

        [Key]
        public int OrdenCompraId
        {
            get { return ordenCompraId; }
            set { ordenCompraId = value; }
        }

        [Required]
        [ForeignKey(nameof(Proveedor))] 
        public int ProveedorId
        {
            get { return proveedorId; }
            set
            {
                if (value > 0)
                {
                    proveedorId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del proveedor debe ser mayor a 0.");
                }
            }
        }

        public Proveedor? Proveedor { get; set; } 

        [Required]
        public string FechaPedido
        {
            get { return fechaPedido; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    fechaPedido = value;
                }
                else
                {
                    throw new ArgumentException("La fecha del pedido no puede estar vacía.");
                }
            }
        }

        [Required]
        [ForeignKey(nameof(EstadoOrdenCompra))] 
        public int EstadoOrdenCompraId
        {
            get { return estadoOrdenCompraId; }
            set
            {
                if (value > 0)
                {
                    estadoOrdenCompraId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID del estado de la orden de compra debe ser mayor a 0.");
                }
            }
        }

        public EstadoOrdenCompra? EstadoOrdenCompra { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal MontoTotal
        {
            get { return montoTotal; }
            set
            {
                if (value >= 0)
                {
                    montoTotal = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El monto total no puede ser negativo.");
                }
            }
        }
    }
}
