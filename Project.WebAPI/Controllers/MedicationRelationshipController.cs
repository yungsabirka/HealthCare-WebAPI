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
    public class MedicationRelationshipController : ControllerBase
    {
        private readonly MedicationRelationshipContext _context;

        public MedicationRelationshipController(MedicationRelationshipContext context)
        {
            _context = context;
        }

        // GET: api/MedicationRelationship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicationRelationship>>> GetMedicationRelationships()
        {
          if (_context.MedicationRelationships == null)
          {
              return NotFound();
          }
            return await _context.MedicationRelationships.ToListAsync();
        }

        // GET: api/MedicationRelationship/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicationRelationship>> GetMedicationRelationship(int id)
        {
          if (_context.MedicationRelationships == null)
          {
              return NotFound();
          }
            var medicationRelationship = await _context.MedicationRelationships.FindAsync(id);

            if (medicationRelationship == null)
            {
                return NotFound();
            }

            return medicationRelationship;
        }

        // PUT: api/MedicationRelationship/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicationRelationship(int id, MedicationRelationship medicationRelationship)
        {
            if (id != medicationRelationship.MedicationRelationshipId)
            {
                return BadRequest();
            }

            _context.Entry(medicationRelationship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationRelationshipExists(id))
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

        // POST: api/MedicationRelationship
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicationRelationship>> PostMedicationRelationship(MedicationRelationship medicationRelationship)
        {
          if (_context.MedicationRelationships == null)
          {
              return Problem("Entity set 'MedicationRelationshipContext.MedicationRelationships'  is null.");
          }
            _context.MedicationRelationships.Add(medicationRelationship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicationRelationship", new { id = medicationRelationship.MedicationRelationshipId }, medicationRelationship);
        }

        // DELETE: api/MedicationRelationship/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicationRelationship(int id)
        {
            if (_context.MedicationRelationships == null)
            {
                return NotFound();
            }
            var medicationRelationship = await _context.MedicationRelationships.FindAsync(id);
            if (medicationRelationship == null)
            {
                return NotFound();
            }

            _context.MedicationRelationships.Remove(medicationRelationship);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicationRelationshipExists(int id)
        {
            return (_context.MedicationRelationships?.Any(e => e.MedicationRelationshipId == id)).GetValueOrDefault();
        }
    }
}
