using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carniceria_Api.Data;
using Carniceria_Api.Models;

namespace Carniceria_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVentasController : ControllerBase
    {
        private readonly SmartsofTomasbenitezContext _context;

        public ApiVentasController(SmartsofTomasbenitezContext context)
        {
            _context = context;
        }

        // GET: api/ApiVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
          if (_context.Ventas == null)
          {
              return NotFound();
          }
            return await _context.Ventas.ToListAsync();
        }

        // GET: api/ApiVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
          if (_context.Ventas == null)
          {
              return NotFound();
          }
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        // PUT: api/ApiVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
          if (_context.Ventas == null)
          {
              return Problem("Entity set 'SmartsofTomasbenitezContext.Ventas'  is null.");
          }
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
        }

        // DELETE: api/ApiVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return (_context.Ventas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
