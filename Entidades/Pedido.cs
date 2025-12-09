using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Pedido
    {
        private int pedidoId;
        private Cliente cliente;
        private int clienteId;
        private List<DetallePedido> detallesPedido = new List<DetallePedido>(); 
        private DateTime fechaPedido;
        private EstadoPedido estadoPedido;
        private int estadoPedidoId;
        private bool pagoDeContado;
        private Financiamiento financiamientoSeleccionado;
        private int? financiamientoId;
   
        [Key]
        public int PedidoId
        {
            get { return pedidoId; }
            set { pedidoId = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }

        public List<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>(); 

        public DateTime FechaPedido
        {
            get { return fechaPedido; }
            set { fechaPedido = value; }
        }

        [ForeignKey("EstadoPedidoId")]
        public EstadoPedido EstadoPedido
        {
            get { return estadoPedido; }
            set { estadoPedido = value; }
        }

        public int EstadoPedidoId
        {
            get { return estadoPedidoId; }
            set { estadoPedidoId = value; }
        }

        public bool PagoDeContado
        {
            get { return pagoDeContado; }
            set { pagoDeContado = value; }
        }

        [ForeignKey("FinanciamientoId")]
        public Financiamiento FinanciamientoSeleccionado
        {
            get { return financiamientoSeleccionado; }
            set { financiamientoSeleccionado = value; }
        }

        public int? FinanciamientoId
        {
            get { return financiamientoId; }
            set { financiamientoId = value; }
        }

        /*[ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        public int VehiculoId
        {
            get { return vehiculoId; }
            set { vehiculoId = value; }
        }*/
    }
}
