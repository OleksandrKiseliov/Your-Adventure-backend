using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourAdventure.Models;

namespace YourAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitedCountriesController : ControllerBase
    {
        private readonly Your_adventure2Context _context;

        public VisitedCountriesController(Your_adventure2Context context)
        {
            _context = context;
        }

        // GET: api/VisitedCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitedCountry>>> GetVisitedCountries()
        {
          if (_context.VisitedCountries == null)
          {
              return NotFound();
          }
            return await _context.VisitedCountries.ToListAsync();
        }

        // GET: api/VisitedCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitedCountry>> GetVisitedCountry(int id)
        {
          if (_context.VisitedCountries == null)
          {
              return NotFound();
          }
            var visitedCountry = await _context.VisitedCountries.FindAsync(id);

            if (visitedCountry == null)
            {
                return NotFound();
            }

            return visitedCountry;
        }

        // PUT: api/VisitedCountries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitedCountry(int id, VisitedCountry visitedCountry)
        {
            if (id != visitedCountry.VisitedCountries)
            {
                return BadRequest();
            }

            _context.Entry(visitedCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitedCountryExists(id))
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

        // POST: api/VisitedCountries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitedCountry>> PostVisitedCountry(VisitedCountry visitedCountry)
        {
          if (_context.VisitedCountries == null)
          {
              return Problem("Entity set 'Your_adventure2Context.VisitedCountries'  is null.");
          }
            _context.VisitedCountries.Add(visitedCountry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitedCountryExists(visitedCountry.VisitedCountries))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVisitedCountry", new { id = visitedCountry.VisitedCountries }, visitedCountry);
        }

        // DELETE: api/VisitedCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitedCountry(int id)
        {
            if (_context.VisitedCountries == null)
            {
                return NotFound();
            }
            var visitedCountry = await _context.VisitedCountries.FindAsync(id);
            if (visitedCountry == null)
            {
                return NotFound();
            }

            _context.VisitedCountries.Remove(visitedCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitedCountryExists(int id)
        {
            return (_context.VisitedCountries?.Any(e => e.VisitedCountries == id)).GetValueOrDefault();
        }
    }
}
