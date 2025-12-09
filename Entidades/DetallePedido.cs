using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entidades;

public class DetallePedido
{
    [Key]
    public int DetallePedidoId { get; set; }

    public Vehiculo Vehiculo { get; set; }
    public int VehiculoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public Pedido Pedido { get; set; }  // Nombre con mayúscula para evitar conflictos
    public int PedidoId { get; set; }


}
