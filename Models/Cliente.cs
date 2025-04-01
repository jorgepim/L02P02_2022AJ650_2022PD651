using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
