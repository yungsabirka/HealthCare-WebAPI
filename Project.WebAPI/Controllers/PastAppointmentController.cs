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
    public class PastAppointmentController : ControllerBase
    {
        private readonly PastAppointmentContext _context;

        public PastAppointmentController(PastAppointmentContext context)
        {
            _context = context;
        }

        // GET: api/PastAppointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastAppointment>>> GetPastAppointments()
        {
          if (_context.PastAppointments == null)
          {
              return NotFound();
          }
            return await _context.PastAppointments.ToListAsync();
        }

        // GET: api/PastAppointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastAppointment>> GetPastAppointment(int id)
        {
          if (_context.PastAppointments == null)
          {
              return NotFound();
          }
            var pastAppointment = await _context.PastAppointments.FindAsync(id);

            if (pastAppointment == null)
            {
                return NotFound();
            }

            return pastAppointment;
        }

        // PUT: api/PastAppointment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastAppointment(int id, PastAppointment pastAppointment)
        {
            if (id != pastAppointment.PastAppointmentKey)
            {
                return BadRequest();
            }

            _context.Entry(pastAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastAppointmentExists(id))
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

        // POST: api/PastAppointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PastAppointment>> PostPastAppointment(PastAppointment pastAppointment)
        {
          if (_context.PastAppointments == null)
          {
              return Problem("Entity set 'PastAppointmentContext.PastAppointments'  is null.");
          }
            _context.PastAppointments.Add(pastAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastAppointment", new { id = pastAppointment.PastAppointmentKey }, pastAppointment);
        }

        // DELETE: api/PastAppointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastAppointment(int id)
        {
            if (_context.PastAppointments == null)
            {
                return NotFound();
            }
            var pastAppointment = await _context.PastAppointments.FindAsync(id);
            if (pastAppointment == null)
            {
                return NotFound();
            }

            _context.PastAppointments.Remove(pastAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastAppointmentExists(int id)
        {
            return (_context.PastAppointments?.Any(e => e.PastAppointmentKey == id)).GetValueOrDefault();
        }
    }
}
