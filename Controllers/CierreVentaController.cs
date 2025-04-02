using Microsoft.AspNetCore.Mvc;
using L02P02_2022AJ650_2022PD651.Models;

namespace L02P02_2022AJ650_2022PD651.Controllers
{
    public class CierreVentaController : Controller
    {
        private readonly LibreriaContext _context;

        public CierreVentaController(LibreriaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Confirmacion()
        {
            return View("Confirmacion");
        }


        public IActionResult Index(int idPedido)
        {
            var pedido = _context.pedido_encabezado
                .FirstOrDefault(p => p.id == idPedido);

            if (pedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            var cliente = _context.clientes
                .FirstOrDefault(c => c.id == pedido.id_cliente);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            var detalles = _context.pedido_detalle
                .Where(pd => pd.id_pedido == idPedido)
                .ToList();

            var libros = (from pd in detalles
                          join l in _context.libros on pd.id_libro equals l.id
                          join a in _context.autores on l.id_autor equals a.id
                          select new
                          {
                              l.id,
                              l.nombre,
                              l.precio,
                              autor_nombre = a.autor
                          }).ToList();

            ViewBag.Libros = libros;
            ViewBag.TotalLibros = libros.Count;
            ViewBag.TotalPrecio = libros.Sum(l => l.precio);
            ViewBag.IdPedido = idPedido;

            return View(cliente);  // Enviamos el modelo cliente correctamente
        }

        [HttpPost]
        public IActionResult CerrarVenta(int idPedido)
        {
            var pedido = _context.pedido_encabezado
                .FirstOrDefault(p => p.id == idPedido);

            if (pedido != null)
            {
                pedido.estado = 'C'; // C = CERRADA
                _context.SaveChanges();
                return RedirectToAction("Confirmacion", "CierreVenta");
            }

            return RedirectToAction("Index", new { idPedido = idPedido });
        }
    }
}
