using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class PedidoDetalle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PedidoEncabezado")]
        public int IdPedido { get; set; }
        public PedidoEncabezado PedidoEncabezado { get; set; }

        [ForeignKey("Libro")]
        public int IdLibro { get; set; }
        public Libro Libro { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
