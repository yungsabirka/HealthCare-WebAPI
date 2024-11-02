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
    public class MedicalCardController : ControllerBase
    {
        private readonly MedicalCardContext _context;

        public MedicalCardController(MedicalCardContext context)
        {
            _context = context;
        }

        // GET: api/MedicalCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalCard>>> GetMedicalCards()
        {
          if (_context.MedicalCards == null)
          {
              return NotFound();
          }
            return await _context.MedicalCards.ToListAsync();
        }

        // GET: api/MedicalCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalCard>> GetMedicalCard(int id)
        {
          if (_context.MedicalCards == null)
          {
              return NotFound();
          }
            var medicalCard = await _context.MedicalCards.FindAsync(id);

            if (medicalCard == null)
            {
                return NotFound();
            }

            return medicalCard;
        }

        // PUT: api/MedicalCard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalCard(int id, MedicalCard medicalCard)
        {
            if (id != medicalCard.MedicalCardId)
            {
                return BadRequest();
            }

            _context.Entry(medicalCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalCardExists(id))
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

        // POST: api/MedicalCard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalCard>> PostMedicalCard(MedicalCard medicalCard)
        {
          if (_context.MedicalCards == null)
          {
              return Problem("Entity set 'MedicalCardContext.MedicalCards'  is null.");
          }
            _context.MedicalCards.Add(medicalCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalCard", new { id = medicalCard.MedicalCardId }, medicalCard);
        }

        // DELETE: api/MedicalCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalCard(int id)
        {
            if (_context.MedicalCards == null)
            {
                return NotFound();
            }
            var medicalCard = await _context.MedicalCards.FindAsync(id);
            if (medicalCard == null)
            {
                return NotFound();
            }

            _context.MedicalCards.Remove(medicalCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalCardExists(int id)
        {
            return (_context.MedicalCards?.Any(e => e.MedicalCardId == id)).GetValueOrDefault();
        }
    }
}
