using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L02P02_2022AJ650_2022PD651.Models;

namespace L02P02_2022AJ650_2022PD651.Controllers
{
    public class ClientesController : Controller
    {
        private readonly LibreriaContext _context;

        public ClientesController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(clientes cliente)
        {
            if (ModelState.IsValid)
            {
                // Generar el nuevo ID de cliente manualmente
                int newId = 1;
                var lastCliente = _context.clientes.OrderByDescending(c => c.id).FirstOrDefault();
                if (lastCliente != null)
                {
                    newId = lastCliente.id + 1;
                }

                cliente.id = newId;
                cliente.created_at = DateTime.Now;

                _context.clientes.Add(cliente);
                await _context.SaveChangesAsync();

                // Crear el encabezado del pedido
                var pedidoEncabezado = new pedido_encabezado
                {
                    id_cliente = cliente.id,
                    cantidad_libros = 0,
                    total = 0,
                    estado = 'P'
                };

                int newPedidoId = 1;
                var lastPedido = _context.pedido_encabezado.OrderByDescending(p => p.id).FirstOrDefault();
                if (lastPedido != null)
                {
                    newPedidoId = lastPedido.id + 1;
                }
                pedidoEncabezado.id = newPedidoId;

                _context.pedido_encabezado.Add(pedidoEncabezado);
                await _context.SaveChangesAsync();

                // Redirigir al carrito con el ID del pedido creado
                return RedirectToAction("Index", "Carrito", new { idPedido = pedidoEncabezado.id });
            }

            return View(cliente);
        }


        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Direccion,CreatedAt")] clientes cliente)
        {
            if (id != cliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.clientes.Any(e => e.id == id);
        }
    }
}
