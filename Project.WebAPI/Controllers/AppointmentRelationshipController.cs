using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentRelationshipController : ControllerBase
    {
        private readonly AppointmentRelationshipContext _context;

        public AppointmentRelationshipController(AppointmentRelationshipContext context)
        {
            _context = context;
        }

        // GET: api/AppointmentRelationship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentRelationship>>> GetAppointmentRelationships()
        {
          if (_context.AppointmentRelationships == null)
          {
              return NotFound();
          }
            return await _context.AppointmentRelationships.ToListAsync();
        }

        // GET: api/AppointmentRelationship/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentRelationship>> GetAppointmentRelationship(int id)
        {
          if (_context.AppointmentRelationships == null)
          {
              return NotFound();
          }
            var appointmentRelationship = await _context.AppointmentRelationships.FindAsync(id);

            if (appointmentRelationship == null)
            {
                return NotFound();
            }

            return appointmentRelationship;
        }

        // PUT: api/AppointmentRelationship/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentRelationship(int id, AppointmentRelationship appointmentRelationship)
        {
            if (id != appointmentRelationship.AppointmentRelationshipId)
            {
                return BadRequest();
            }

            _context.Entry(appointmentRelationship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentRelationshipExists(id))
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

        // POST: api/AppointmentRelationship
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentRelationship>> PostAppointmentRelationship(AppointmentRelationship appointmentRelationship)
        {
          if (_context.AppointmentRelationships == null)
          {
              return Problem("Entity set 'AppointmentRelationshipContext.AppointmentRelationships'  is null.");
          }
            _context.AppointmentRelationships.Add(appointmentRelationship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentRelationship", new { id = appointmentRelationship.AppointmentRelationshipId }, appointmentRelationship);
        }

        // DELETE: api/AppointmentRelationship/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentRelationship(int id)
        {
            if (_context.AppointmentRelationships == null)
            {
                return NotFound();
            }
            var appointmentRelationship = await _context.AppointmentRelationships.FindAsync(id);
            if (appointmentRelationship == null)
            {
                return NotFound();
            }

            _context.AppointmentRelationships.Remove(appointmentRelationship);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentRelationshipExists(int id)
        {
            return (_context.AppointmentRelationships?.Any(e => e.AppointmentRelationshipId == id)).GetValueOrDefault();
        }

    }
}
