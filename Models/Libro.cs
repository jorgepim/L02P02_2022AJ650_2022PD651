using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        [MaxLength(255)]
        public string UrlImagen { get; set; }

        public decimal Precio { get; set; }

        public char Estado { get; set; }

        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
        public Autor Autor { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
