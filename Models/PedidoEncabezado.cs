using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class PedidoEncabezado
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public int CantidadLibros { get; set; }
        public decimal Total { get; set; }
        public char estado { get; set; }
    }
}
