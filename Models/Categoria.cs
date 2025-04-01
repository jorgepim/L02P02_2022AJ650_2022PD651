using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
    }
}
