using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class MedicalCardContext : DbContext
    {
        public MedicalCardContext(DbContextOptions<MedicalCardContext> options) : base(options)
        {
        }
        public DbSet<MedicalCard> MedicalCards { get; set; }
    }
}
