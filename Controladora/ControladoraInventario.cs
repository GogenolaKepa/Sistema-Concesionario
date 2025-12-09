using Entidades;
using Modelo;
using System;

namespace Controladoras
{
    public class ControladoraInventario
    {
        private readonly Concesionario _context;

        public ControladoraInventario(Concesionario context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                throw new ArgumentNullException(nameof(vehiculo), "El vehículo no puede ser nulo.");

            if (_context.Vehiculos.Any(v => v.Marca == vehiculo.Marca && v.Modelo == vehiculo.Modelo && v.Anio == vehiculo.Anio))
                throw new Exception("Ya existe un vehículo con la misma marca, modelo y año.");

            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            Console.WriteLine("Vehículo agregado exitosamente.");
        }

        public void EliminarVehiculo(int idVehiculo)
        {
            var vehiculo = _context.Vehiculos.Find(idVehiculo);
            if (vehiculo == null)
                throw new ArgumentException("El vehículo no existe en el inventario.");

            _context.Vehiculos.Remove(vehiculo);
            _context.SaveChanges();
            Console.WriteLine("Vehículo eliminado exitosamente.");
        }

        public void ModificarVehiculo(Vehiculo vehiculoModificado)
        {
            if (vehiculoModificado == null)
                throw new ArgumentNullException(nameof(vehiculoModificado), "El vehículo modificado no puede ser nulo.");

            var vehiculo = _context.Vehiculos.Find(vehiculoModificado.VehiculoId);
            if (vehiculo == null)
                throw new ArgumentException("El vehículo no existe en el inventario.");

            _context.Entry(vehiculo).CurrentValues.SetValues(vehiculoModificado);
            _context.SaveChanges();
            Console.WriteLine("Vehículo modificado exitosamente.");
        }
    }
}
