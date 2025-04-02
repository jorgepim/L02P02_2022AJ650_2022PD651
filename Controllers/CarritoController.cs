using L02P02_2022AJ650_2022PD651.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022AJ650_2022PD651.Controllers
{
    public class CarritoController : Controller
    {
        private readonly LibreriaContext _context;
        public CarritoController(LibreriaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int idPedido=1)
        {
            var libros = (from l in _context.libros
                          join a in _context.autores on l.id_autor equals a.id
                          select new
                          {
                              l.id,
                              l.nombre,
                              l.descripcion,
                              l.url_imagen,
                              l.id_autor,
                              autor_nombre = a.autor,
                              l.id_categoria,
                              l.precio,
                              l.estado
                          }).ToList();
            ViewBag.IdPedido = idPedido;
            ViewBag.Libros = libros;

            var totalLibros = (from pd in _context.pedido_detalle
                               where pd.id_pedido == idPedido
                               select pd).Count();
            ViewBag.TotalLibros = totalLibros;

            decimal totalPrecio = 0;
            List<pedido_detalle> detalles = (from pd in _context.pedido_detalle
                            where pd.id_pedido == idPedido
                            select pd).ToList();

            foreach (var detalle in detalles)
            {
                libros libro = (from l in _context.libros
                             where l.id == detalle.id_libro
                             select l).FirstOrDefault();
                if (libro != null)
                {
                    totalPrecio += libro.precio;
                }
            }

            ViewBag.TotalPrecio = totalPrecio;

            return View();
        }

        [HttpPost]
        public IActionResult AgregarLibro(int idLibro, int idPedido)
        {
            int newId = 1;
            var lastDetalle = _context.pedido_detalle.OrderByDescending(pd => pd.id).FirstOrDefault();
            if (lastDetalle != null)
            {
                newId = lastDetalle.id + 1;
            }

            var libro = (from l in _context.libros
                         where l.id == idLibro
                         select l).FirstOrDefault();

            if (libro != null)
            {
                var pedidoDetalle = new pedido_detalle
                {
                    id = newId,
                    id_pedido = idPedido,
                    id_libro = idLibro,
                    created_at = DateTime.Now
                };

                _context.pedido_detalle.Add(pedidoDetalle);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { idPedido = idPedido });
        }

        public IActionResult CompletarVenta(int idPedido)
        {
            return RedirectToAction("CierreVenta", "Venta", new { idPedido = idPedido });
        }
    }
}
