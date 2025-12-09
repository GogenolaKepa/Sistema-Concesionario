using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Proveedor
    {
        private int proveedorId;
        private string nombreProveedor;
        private string contactoProveedor;
        private int telefonoProveedor;
        private string direccionProveedor;
        private List<Vehiculo> vehiculosSuministrados;


        public int ProveedorId
        {
            get { return proveedorId; }
            set { proveedorId = value; }
        }

        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombreProveedor = value;
                }
                else
                {
                    throw new ArgumentException("El nombre del proveedor no puede estar vacío.");
                }
            }
        }

        public string ContactoProveedor
        {
            get { return contactoProveedor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    contactoProveedor = value;
                }
                else
                {
                    throw new ArgumentException("El contacto del proveedor no puede estar vacío.");
                }
            }
        }

        public int TelefonoProveedor
        {
            get { return telefonoProveedor; }
            set
            {
                if (value > 0)
                {
                    telefonoProveedor = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El teléfono del proveedor debe ser un número válido.");
                }
            }
        }

        public string DireccionProveedor
        {
            get { return direccionProveedor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccionProveedor = value;
                }
                else
                {
                    throw new ArgumentException("La dirección del proveedor no puede estar vacía.");
                }
            }
        }

        public List<Vehiculo> VehiculosSuministrados
        {
            get { return vehiculosSuministrados; }
            private set { vehiculosSuministrados = value ?? new List<Vehiculo>(); }
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo != null)
            {
                vehiculosSuministrados.Add(vehiculo);
            }
            else
            {
                throw new ArgumentNullException(nameof(vehiculo), "El vehículo no puede ser nulo.");
            }
        }

        public Proveedor()
        {
            vehiculosSuministrados = new List<Vehiculo>();
        }

        
    }
}
