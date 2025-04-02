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

        public IActionResult Index(int idPedido)
        {
            List<Libro> libros = (from l in _context.Libros
                          select l).ToList();
            ViewBag.IdPedido = idPedido;
            ViewBag.Libros = libros;

            var totalLibros = (from pd in _context.PedidoDetalles
                               where pd.IdPedido == idPedido
                               select pd).Count();
            ViewBag.TotalLibros = totalLibros;

            decimal totalPrecio = 0;
            List<PedidoDetalle> detalles = (from pd in _context.PedidoDetalles
                            where pd.IdPedido == idPedido
                            select pd).ToList();

            foreach (var detalle in detalles)
            {
                Libro libro = (from l in _context.Libros
                             where l.Id == detalle.IdLibro
                             select l).FirstOrDefault();
                if (libro != null)
                {
                    totalPrecio += libro.Precio;
                }
            }

            ViewBag.TotalPrecio = totalPrecio;

            return View();
        }

        [HttpPost]
        public IActionResult AgregarLibro(int idLibro, int idPedido)
        {
            Libro libro = (from l in _context.Libros
                         where l.Id == idLibro
                         select l).FirstOrDefault();

            if (libro != null)
            {
                PedidoDetalle pedidoDetalle = new PedidoDetalle
                {
                    IdPedido = idPedido,
                    IdLibro = idLibro,
                    CreatedAt = DateTime.Now
                };

                _context.PedidoDetalles.Add(pedidoDetalle);
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
