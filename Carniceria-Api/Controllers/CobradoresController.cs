using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carniceria_Api.Data;
using Carniceria_Api.Models;

namespace Carniceria_Api.Controllers
{
    public class CobradoresController : Controller
    {
        private readonly SmartsofTomasbenitezContext _context;

        public CobradoresController(SmartsofTomasbenitezContext context)
        {
            _context = context;
        }

        // GET: Cobradores
        public async Task<IActionResult> Index()
        {
              return _context.Cobradors != null ? 
                          View(await _context.Cobradors.ToListAsync()) :
                          Problem("Entity set 'SmartsofTomasbenitezContext.Cobradors'  is null.");
        }

        // GET: Cobradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobradors == null)
            {
                return NotFound();
            }

            var cobrador = await _context.Cobradors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrador == null)
            {
                return NotFound();
            }

            return View(cobrador);
        }

        // GET: Cobradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cobradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApellidoNombre,Dirección,Teléfono,Password,TipoUsuario")] Cobrador cobrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cobrador);
        }

        // GET: Cobradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobradors == null)
            {
                return NotFound();
            }

            var cobrador = await _context.Cobradors.FindAsync(id);
            if (cobrador == null)
            {
                return NotFound();
            }
            return View(cobrador);
        }

        // POST: Cobradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApellidoNombre,Dirección,Teléfono,Password,TipoUsuario")] Cobrador cobrador)
        {
            if (id != cobrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobradorExists(cobrador.Id))
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
            return View(cobrador);
        }

        // GET: Cobradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobradors == null)
            {
                return NotFound();
            }

            var cobrador = await _context.Cobradors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrador == null)
            {
                return NotFound();
            }

            return View(cobrador);
        }

        // POST: Cobradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobradors == null)
            {
                return Problem("Entity set 'SmartsofTomasbenitezContext.Cobradors'  is null.");
            }
            var cobrador = await _context.Cobradors.FindAsync(id);
            if (cobrador != null)
            {
                _context.Cobradors.Remove(cobrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobradorExists(int id)
        {
          return (_context.Cobradors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
