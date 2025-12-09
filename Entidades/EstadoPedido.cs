using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class EstadoPedido
    {
        private int estadoPedidoId;
        private string descripcion;
        private string estadoActual;


        [Key]
        public int EstadoPedidoId
        {
            get { return estadoPedidoId; }
            set { estadoPedidoId = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }
    }
}
