using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }

        public int id_libro { get; set; }

        public string comentarios { get; set; }

        [MaxLength(50)]
        public string usuario { get; set; }

        public DateTime created_at { get; set; }
    }
}
