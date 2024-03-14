﻿using System;
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
    public class SettingsController : ControllerBase
    {
        private readonly Your_adventure2Context _context;

        public SettingsController(Your_adventure2Context context)
        {
            _context = context;
        }

        // GET: api/Settings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setting>>> GetSettings()
        {
          if (_context.Settings == null)
          {
              return NotFound();
          }
            return await _context.Settings.ToListAsync();
        }

        // GET: api/Settings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Setting>> GetSetting(int id)
        {
          if (_context.Settings == null)
          {
              return NotFound();
          }
            var setting = await _context.Settings.FindAsync(id);

            if (setting == null)
            {
                return NotFound();
            }

            return setting;
        }

        // PUT: api/Settings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetting(int id, Setting setting)
        {
            if (id != setting.SettingsId)
            {
                return BadRequest();
            }

            _context.Entry(setting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingExists(id))
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

        // POST: api/Settings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Setting>> PostSetting(Setting setting)
        {
          if (_context.Settings == null)
          {
              return Problem("Entity set 'Your_adventure2Context.Settings'  is null.");
          }
            _context.Settings.Add(setting);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SettingExists(setting.SettingsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSetting", new { id = setting.SettingsId }, setting);
        }

        // DELETE: api/Settings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetting(int id)
        {
            if (_context.Settings == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SettingExists(int id)
        {
            return (_context.Settings?.Any(e => e.SettingsId == id)).GetValueOrDefault();
        }
    }
}
