using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class AppointmentRelationshipContext : DbContext
    {
        public AppointmentRelationshipContext(DbContextOptions<AppointmentRelationshipContext> options) : base(options)
        {
        }
        public DbSet<AppointmentRelationship> AppointmentRelationships { get; set; }
    }
}
