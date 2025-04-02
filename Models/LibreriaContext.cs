using Microsoft.EntityFrameworkCore;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class LibreriaContext:DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
        }
        public DbSet<libros> libros { get; set; }
        public DbSet<autores> autores { get; set; }
        public DbSet<categorias> categorias { get; set; }
        public DbSet<pedido_encabezado> pedido_encabezado { get; set; }
        public DbSet<pedido_detalle> pedido_detalle { get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<comentarios_libros> comentarios_libros { get; set; }

    }
}
