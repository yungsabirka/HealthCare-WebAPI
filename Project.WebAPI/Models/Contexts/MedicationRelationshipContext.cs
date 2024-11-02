using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class MedicationRelationshipContext : DbContext
    {
        public MedicationRelationshipContext(DbContextOptions<MedicationRelationshipContext> options) : base(options)
        {
        }
        public DbSet<MedicationRelationship> MedicationRelationships { get; set; }
    }
}
