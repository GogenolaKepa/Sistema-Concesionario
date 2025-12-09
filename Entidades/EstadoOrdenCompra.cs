using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class EstadoOrdenCompra
    {
        private int estadoOrdenCompraId;
        private string estadoActual;

        public static readonly string Pendiente = "Pendiente";
        public static readonly string Confirmado = "Confirmado";
        public static readonly string Cancelado = "Cancelado";
        public static readonly string PorEntregar = "Por Entregar";
        public static readonly string Entregado = "Entregado";
        public static readonly string EntregadoConFaltante = "Entregado con Faltante";
        public static readonly string ParcialmenteEntregado = "Parcialmente Entregado";

        [Key] 
        public int EstadoOrdenCompraId
        {
            get { return estadoOrdenCompraId; }
            set { estadoOrdenCompraId = value; }
        }

        [Required] 
        [MaxLength(50)] 
        public string EstadoActual
        {
            get { return estadoActual; }
            set
            {
                if (EsEstadoValido(value))
                {
                    estadoActual = value;
                }
                else
                {
                    throw new ArgumentException("Estado no válido");
                }
            }
        }

        public EstadoOrdenCompra()
        {
            estadoActual = Pendiente;
        }

        private bool EsEstadoValido(string estado)
        {
            return estado == Pendiente || estado == Confirmado || estado == Cancelado ||
                   estado == PorEntregar || estado == Entregado ||
                   estado == EntregadoConFaltante || estado == ParcialmenteEntregado;
        }
    }
}
