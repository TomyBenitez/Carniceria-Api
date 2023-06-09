﻿using System;
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
    public class VentasController : Controller
    {
        private readonly SmartsofTomasbenitezContext _context;

        public VentasController(SmartsofTomasbenitezContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var smartsofTomasbenitezContext = _context.Ventas.Include(v => v.Cliente).Include(v => v.Cobrador).Include(v => v.Producto);
            return View(await smartsofTomasbenitezContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Cobrador)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["CobradorId"] = new SelectList(_context.Cobradors, "Id", "Id");
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venta venta)
        {
            if (venta != null)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // Aquí puedes hacer lo que necesites con el error, como imprimirlo en la consola o enviarlo a una página de error.
                        Console.WriteLine("Error en el modelo: " + error.ErrorMessage);
                    }
                }
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradors, "Id", "Id", venta.CobradorId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", venta.ProductosId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradors, "Id", "Id", venta.CobradorId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", venta.ProductosId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            if (venta != null)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradors, "Id", "Id", venta.CobradorId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", venta.ProductosId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Cobrador)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'SmartsofTomasbenitezContext.Ventas'  is null.");
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return (_context.Ventas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
