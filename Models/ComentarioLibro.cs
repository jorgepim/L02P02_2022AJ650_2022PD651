using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class ComentarioLibro
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Libro")]
        public int IdLibro { get; set; }
        public Libro Libro { get; set; }

        public string Comentarios { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
