using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class MedicationContext : DbContext
    {
        public MedicationContext(DbContextOptions<MedicationContext> options) : base(options)
        {
        }
        public DbSet<Medication> Medications { get; set; }
    }
}
