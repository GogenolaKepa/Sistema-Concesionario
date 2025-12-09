using System;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controladoras
{
    public class ControladoraCompra
    {
        private readonly Concesionario _context;

        public ControladoraCompra(Concesionario context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }

        public void RealizarCompra(int vehiculoId, int proveedorId, decimal precioAcordado)
        {
            // Buscar el vehículo en el inventario
            var vehiculo = _context.Vehiculos.Find(vehiculoId);
            if (vehiculo == null || !vehiculo.Disponibilidad)
            {
                throw new Exception("El vehículo no está disponible para la compra.");
            }

            // Buscar el proveedor
            var proveedor = _context.Proveedores
                                    .Include(p => p.VehiculosSuministrados)
                                    .FirstOrDefault(p => p.ProveedorId == proveedorId);
            if (proveedor == null)
            {
                throw new Exception("Proveedor no encontrado.");
            }

            var nuevaOrdenCompra = new OrdenCompra
            {
                ProveedorId = proveedorId, 
                FechaPedido = DateTime.Now.ToString("yyyy-MM-dd"),
                EstadoOrdenCompraId = 1, // Estado "Confirmado" 
                MontoTotal = precioAcordado
            };

            _context.OrdenesCompra.Add(nuevaOrdenCompra);
            _context.SaveChanges(); 

            // Crear el detalle de compra
            var detalleCompra = new DetalleCompra
            {
                OrdenCompraId = nuevaOrdenCompra.OrdenCompraId, // Se usa el ID correcto
                VehiculoId = vehiculoId,
                Cantidad = 1,
                PrecioUnitario = precioAcordado
            };

            _context.DetallesCompra.Add(detalleCompra);

            // Marcar el vehículo como no disponible
            vehiculo.Disponibilidad = false;
            _context.Vehiculos.Update(vehiculo);

            proveedor.AgregarVehiculo(vehiculo);

            _context.SaveChanges();

            Console.WriteLine($"Compra realizada con éxito. Vehículo {vehiculo.Marca} {vehiculo.Modelo} comprado a {proveedor.NombreProveedor}.");
        }
    }
}
