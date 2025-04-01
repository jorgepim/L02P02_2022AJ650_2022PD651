using Microsoft.EntityFrameworkCore;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class LibreriaContext:DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<PedidoEncabezado> PedidoEncabezados { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ComentarioLibro> ComentariosLibros { get; set; }

    }
}
