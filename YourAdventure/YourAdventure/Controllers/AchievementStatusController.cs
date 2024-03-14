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
    public class AchievementStatusController : ControllerBase
    {
        private readonly Your_adventure2Context _context;

        public AchievementStatusController(Your_adventure2Context context)
        {
            _context = context;
        }

        // GET: api/AchievementStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementStatus>>> GetAchievementStatuses()
        {
          if (_context.AchievementStatuses == null)
          {
              return NotFound();
          }
            return await _context.AchievementStatuses.ToListAsync();
        }

        // GET: api/AchievementStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementStatus>> GetAchievementStatus(int id)
        {
          if (_context.AchievementStatuses == null)
          {
              return NotFound();
          }
            var achievementStatus = await _context.AchievementStatuses.FindAsync(id);

            if (achievementStatus == null)
            {
                return NotFound();
            }

            return achievementStatus;
        }

        // PUT: api/AchievementStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchievementStatus(int id, AchievementStatus achievementStatus)
        {
            if (id != achievementStatus.AchievementStatusId)
            {
                return BadRequest();
            }

            _context.Entry(achievementStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementStatusExists(id))
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

        // POST: api/AchievementStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AchievementStatus>> PostAchievementStatus(AchievementStatus achievementStatus)
        {
          if (_context.AchievementStatuses == null)
          {
              return Problem("Entity set 'Your_adventure2Context.AchievementStatuses'  is null.");
          }
            _context.AchievementStatuses.Add(achievementStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AchievementStatusExists(achievementStatus.AchievementStatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAchievementStatus", new { id = achievementStatus.AchievementStatusId }, achievementStatus);
        }

        // DELETE: api/AchievementStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievementStatus(int id)
        {
            if (_context.AchievementStatuses == null)
            {
                return NotFound();
            }
            var achievementStatus = await _context.AchievementStatuses.FindAsync(id);
            if (achievementStatus == null)
            {
                return NotFound();
            }

            _context.AchievementStatuses.Remove(achievementStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchievementStatusExists(int id)
        {
            return (_context.AchievementStatuses?.Any(e => e.AchievementStatusId == id)).GetValueOrDefault();
        }
    }
}
