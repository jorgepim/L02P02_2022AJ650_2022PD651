using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class libros
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string nombre { get; set; }

        [MaxLength(255)]
        public string descripcion { get; set; }

        [MaxLength(255)]
        public string url_imagen { get; set; }

        public int id_autor { get; set; }

        public int id_categoria { get; set; }

        public decimal precio { get; set; }
        public char estado { get; set; }

    }
}
