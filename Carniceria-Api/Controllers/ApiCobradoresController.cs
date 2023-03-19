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
    public class ApiCobradoresController : ControllerBase
    {
        private readonly SmartsofTomasbenitezContext _context;

        public ApiCobradoresController(SmartsofTomasbenitezContext context)
        {
            _context = context;
        }

        // GET: api/ApiCobradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobrador>>> GetCobradors()
        {
          if (_context.Cobradors == null)
          {
              return NotFound();
          }
            return await _context.Cobradors.ToListAsync();
        }

        // GET: api/ApiCobradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobrador>> GetCobrador(int id)
        {
          if (_context.Cobradors == null)
          {
              return NotFound();
          }
            var cobrador = await _context.Cobradors.FindAsync(id);

            if (cobrador == null)
            {
                return NotFound();
            }

            return cobrador;
        }

        // PUT: api/ApiCobradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobrador(int id, Cobrador cobrador)
        {
            if (id != cobrador.Id)
            {
                return BadRequest();
            }

            _context.Entry(cobrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobradorExists(id))
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

        // POST: api/ApiCobradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cobrador>> PostCobrador(Cobrador cobrador)
        {
          if (_context.Cobradors == null)
          {
              return Problem("Entity set 'SmartsofTomasbenitezContext.Cobradors'  is null.");
          }
            _context.Cobradors.Add(cobrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCobrador", new { id = cobrador.Id }, cobrador);
        }

        // DELETE: api/ApiCobradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobrador(int id)
        {
            if (_context.Cobradors == null)
            {
                return NotFound();
            }
            var cobrador = await _context.Cobradors.FindAsync(id);
            if (cobrador == null)
            {
                return NotFound();
            }

            _context.Cobradors.Remove(cobrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CobradorExists(int id)
        {
            return (_context.Cobradors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
