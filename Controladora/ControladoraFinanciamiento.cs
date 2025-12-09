using System;
using System.Linq;
using Entidades;
using Modelo; 
using Microsoft.EntityFrameworkCore;

namespace Controladoras
{
    public class ControladoraPedido
    {
        private readonly Concesionario _context;

        public ControladoraPedido(Concesionario context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IQueryable<Financiamiento> ObtenerOpcionesFinanciamiento()
        {
            return _context.Financiamientos.AsQueryable();
        }


        public void SeleccionarFinanciamiento(int pedidoId, int financiamientoId)
        {
            var pedido = _context.Pedidos.Find(pedidoId);
            if (pedido == null)
                throw new ArgumentException("Pedido no encontrado.");

            var financiamiento = _context.Financiamientos.Find(financiamientoId);
            if (financiamiento == null)
                throw new ArgumentException("Financiamiento no encontrado.");

            // Mostrar los términos y condiciones del financiamiento.
            Console.WriteLine("Términos y condiciones:");
            Console.WriteLine(financiamiento.TerminosYCondicionesFinanciamiento);
            Console.WriteLine("Confirma la selección del financiamiento? (s/n)");
            var confirmacion = Console.ReadLine();

            if (confirmacion?.ToLower() == "s")
            {
                pedido.FinanciamientoSeleccionado = financiamiento;
                pedido.PagoDeContado = false;
                _context.SaveChanges();
                Console.WriteLine("Financiamiento seleccionado y guardado en el pedido.");
            }
            else
            {
                Console.WriteLine("Selección de financiamiento cancelada.");
            }
        }


        public void SeleccionarPagoDeContado(int pedidoId)
        {
            var pedido = _context.Pedidos.Find(pedidoId);
            if (pedido == null)
                throw new ArgumentException("Pedido no encontrado.");

            Console.WriteLine("Confirma la selección de pago de contado? (s/n)");
            var confirmacion = Console.ReadLine();

            if (confirmacion?.ToLower() == "s")
            {
                pedido.FinanciamientoSeleccionado = null;
                pedido.PagoDeContado = true;
                _context.SaveChanges();
                Console.WriteLine("El pedido se ha registrado como pago de contado.");
            }
            else
            {
                Console.WriteLine("Selección de pago de contado cancelada.");
            }
        }
    }
}
