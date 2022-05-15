using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mutual_MyPJ_HP.Data;
using Mutual_MyPJ_HP.Data.Entities;

namespace Mutual_MyPJ_HP.Controllers
{
    public class ClientesTiposController : Controller
    {
        private readonly DataContext _context;

        public ClientesTiposController(DataContext context)
        {
            _context = context;
        }

        // GET: ClientesTipos
        public async Task<IActionResult> Index()
        {
              return View(await _context.ClientesTipos.ToListAsync());
        }

        // GET: ClientesTipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientesTipos == null)
            {
                return NotFound();
            }

            var clientesTipo = await _context.ClientesTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesTipo == null)
            {
                return NotFound();
            }

            return View(clientesTipo);
        }

        // GET: ClientesTipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesTipos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientesTipo clientesTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesTipo);
        }

        // GET: ClientesTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientesTipos == null)
            {
                return NotFound();
            }

            var clientesTipo = await _context.ClientesTipos.FindAsync(id);
            if (clientesTipo == null)
            {
                return NotFound();
            }
            return View(clientesTipo);
        }

        // POST: ClientesTipos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientesTipo clientesTipo)
        {
            if (id != clientesTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesTipoExists(clientesTipo.Id))
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
            return View(clientesTipo);
        }

        // GET: ClientesTipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientesTipos == null)
            {
                return NotFound();
            }

            var clientesTipo = await _context.ClientesTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesTipo == null)
            {
                return NotFound();
            }

            return View(clientesTipo);
        }

        // POST: ClientesTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientesTipos == null)
            {
                return Problem("Entity set 'DataContext.ClientesTipos'  is null.");
            }
            var clientesTipo = await _context.ClientesTipos.FindAsync(id);
            if (clientesTipo != null)
            {
                _context.ClientesTipos.Remove(clientesTipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesTipoExists(int id)
        {
          return (_context.ClientesTipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
