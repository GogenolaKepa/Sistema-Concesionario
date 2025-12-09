using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; } 

        [Required] 
        public string NombreCliente { get; set; } = string.Empty; 

        [Required]
        [MaxLength(15)] 
        public string NumContacto { get; set; } = string.Empty; 

        [Required]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "El DNI debe tener entre 7 y 8 dígitos.")]
        public string DNI { get; set; } = string.Empty; 

        public string CompraHecha { get; set; } = "No"; 

        public Cliente() { }
    }
}
