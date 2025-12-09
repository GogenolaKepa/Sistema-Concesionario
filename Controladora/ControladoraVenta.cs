using System;
using System.Linq;
using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladoras
{
    public class ControladoraVenta
    {
        private readonly Concesionario _context;

        public ControladoraVenta(Concesionario context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void RealizarVenta(int pedidoId, Cliente datosComprador)
        {
            var pedido = _context.Pedidos
                .Include(p => p.DetallesPedido)
                    .ThenInclude(d => d.Vehiculo) // Incluir la relación con Vehiculo
                .Include(p => p.Cliente)
                .Include(p => p.FinanciamientoSeleccionado)
                .FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido == null)
                throw new ArgumentException("Pedido no encontrado.");

            if (datosComprador == null)
                throw new ArgumentNullException(nameof(datosComprador), "Los datos del comprador son requeridos.");

            if (string.IsNullOrWhiteSpace(datosComprador.NombreCliente))
                throw new Exception("El nombre del comprador es obligatorio.");

            pedido.Cliente = datosComprador;

            if (pedido.FinanciamientoSeleccionado == null && pedido.PagoDeContado == false)
            {
                throw new Exception("No se ha seleccionado un método de pago válido para la venta.");
            }

            // Solicitar confirmación para finalizar la venta.
            Console.WriteLine("¿Confirma los detalles de la venta? (s/n)");
            var confirmacion = Console.ReadLine();
            if (confirmacion?.ToLower() != "s")
            {
                Console.WriteLine("Proceso de venta cancelado. Se guarda estado temporal para retomarlo luego.");
                _context.SaveChanges();
                return;
            }

            if (pedido.DetallesPedido == null || !pedido.DetallesPedido.Any())
            {
                throw new Exception("No se ha asignado un vehículo al pedido.");
            }

            // Marcar los vehículos como no disponibles
            foreach (var detalle in pedido.DetallesPedido)
            {
                if (detalle.Vehiculo != null)
                {
                    detalle.Vehiculo.Disponibilidad = false;
                }
                else
                {
                    throw new Exception("Uno de los detalles del pedido no tiene un vehículo asignado.");
                }
            }

            pedido.EstadoPedido = new EstadoPedido()
            {
          
            };

            _context.SaveChanges();
            Console.WriteLine("Venta realizada exitosamente. Se ha generado el comprobante de venta.");
        }


        public void GuardarVentaTemporal(int pedidoId)
        {
            var pedido = _context.Pedidos.Find(pedidoId);
            if (pedido == null)
                throw new ArgumentException("Pedido no encontrado.");

            Console.WriteLine("Estado de venta guardado temporalmente. Podrás retomarlo más tarde.");
            _context.SaveChanges();
        }
    }
}
