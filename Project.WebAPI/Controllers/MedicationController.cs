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
    public class MedicationController : ControllerBase
    {
        private readonly MedicationContext _context;

        public MedicationController(MedicationContext context)
        {
            _context = context;
        }

        // GET: api/Medication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
          if (_context.Medications == null)
          {
              return NotFound();
          }
            return await _context.Medications.ToListAsync();
        }

        // GET: api/Medication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
          if (_context.Medications == null)
          {
              return NotFound();
          }
            var medication = await _context.Medications.FindAsync(id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }

        // PUT: api/Medication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedication(int id, Medication medication)
        {
            if (id != medication.MedicationId)
            {
                return BadRequest();
            }

            _context.Entry(medication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(id))
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

        // POST: api/Medication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
          if (_context.Medications == null)
          {
              return Problem("Entity set 'MedicationContext.Medications'  is null.");
          }
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedication", new { id = medication.MedicationId }, medication);
        }

        // DELETE: api/Medication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            if (_context.Medications == null)
            {
                return NotFound();
            }
            var medication = await _context.Medications.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicationExists(int id)
        {
            return (_context.Medications?.Any(e => e.MedicationId == id)).GetValueOrDefault();
        }
    }
}
