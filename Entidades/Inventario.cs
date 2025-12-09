using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

public class Inventario
{
    private int inventarioId;
    private List<Vehiculo> vehiculos;
    private Dictionary<int, int> stockVehiculos; 

    public int CantidadDisponible { get; set; }

    public int InventarioId
    {
        get { return inventarioId; }
        set { inventarioId = value; }
    }

    public List<Vehiculo> Vehiculos
    {
        get { return vehiculos; }
        set
        {
            if (value != null)
            {
                vehiculos = value;
            }
            else
            {
                throw new ArgumentNullException(nameof(value), "La lista de vehículos no puede ser nula.");
            }
        }
    }

    public Inventario()
    {
        this.vehiculos = new List<Vehiculo>();
        this.stockVehiculos = new Dictionary<int, int>(); 
    }

    public int ObtenerCantidadDisponible(int vehiculoId)
    {
        return stockVehiculos.ContainsKey(vehiculoId) ? stockVehiculos[vehiculoId] : 0;
    }

    public void AgregarVehiculo(Vehiculo vehiculo, int cantidad)
    {
        if (vehiculo != null)
        {
            vehiculos.Add(vehiculo);
            if (stockVehiculos.ContainsKey(vehiculo.VehiculoId))
            {
                stockVehiculos[vehiculo.VehiculoId] += cantidad;
            }
            else
            {
                stockVehiculos[vehiculo.VehiculoId] = cantidad;
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(vehiculo), "El vehículo no puede ser nulo.");
        }
    }

    public Vehiculo ObtenerVehiculoPorId(int idVehiculo)
    {
        return vehiculos.Find(v => v.VehiculoId == idVehiculo);
    }

    public IEnumerable<Vehiculo> ListarVehiculosEnStock()
    {
        return vehiculos.Where(v => ObtenerCantidadDisponible(v.VehiculoId) > 0);
    }
}
