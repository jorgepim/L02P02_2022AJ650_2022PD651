using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class clientes
    {

        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string apellido { get; set; }

        [Required]
        [MaxLength(255)]
        public string email { get; set; }

        [MaxLength(255)]
        public string direccion { get; set; }

        public DateTime created_at { get; set; }

    }
}
