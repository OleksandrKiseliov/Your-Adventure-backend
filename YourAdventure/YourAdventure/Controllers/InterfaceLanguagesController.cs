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
    public class InterfaceLanguagesController : ControllerBase
    {
        private readonly Your_adventure2Context _context;

        public InterfaceLanguagesController(Your_adventure2Context context)
        {
            _context = context;
        }

        // GET: api/InterfaceLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterfaceLanguage>>> GetInterfaceLanguages()
        {
          if (_context.InterfaceLanguages == null)
          {
              return NotFound();
          }
            return await _context.InterfaceLanguages.ToListAsync();
        }

        // GET: api/InterfaceLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterfaceLanguage>> GetInterfaceLanguage(int id)
        {
          if (_context.InterfaceLanguages == null)
          {
              return NotFound();
          }
            var interfaceLanguage = await _context.InterfaceLanguages.FindAsync(id);

            if (interfaceLanguage == null)
            {
                return NotFound();
            }

            return interfaceLanguage;
        }

        // PUT: api/InterfaceLanguages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterfaceLanguage(int id, InterfaceLanguage interfaceLanguage)
        {
            if (id != interfaceLanguage.InterfaceLanguageId)
            {
                return BadRequest();
            }

            _context.Entry(interfaceLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterfaceLanguageExists(id))
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

        // POST: api/InterfaceLanguages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InterfaceLanguage>> PostInterfaceLanguage(InterfaceLanguage interfaceLanguage)
        {
          if (_context.InterfaceLanguages == null)
          {
              return Problem("Entity set 'Your_adventure2Context.InterfaceLanguages'  is null.");
          }
            _context.InterfaceLanguages.Add(interfaceLanguage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InterfaceLanguageExists(interfaceLanguage.InterfaceLanguageId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInterfaceLanguage", new { id = interfaceLanguage.InterfaceLanguageId }, interfaceLanguage);
        }

        // DELETE: api/InterfaceLanguages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterfaceLanguage(int id)
        {
            if (_context.InterfaceLanguages == null)
            {
                return NotFound();
            }
            var interfaceLanguage = await _context.InterfaceLanguages.FindAsync(id);
            if (interfaceLanguage == null)
            {
                return NotFound();
            }

            _context.InterfaceLanguages.Remove(interfaceLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterfaceLanguageExists(int id)
        {
            return (_context.InterfaceLanguages?.Any(e => e.InterfaceLanguageId == id)).GetValueOrDefault();
        }
    }
}
