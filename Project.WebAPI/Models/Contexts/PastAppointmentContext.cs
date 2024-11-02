using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class PastAppointmentContext : DbContext
    {
        public PastAppointmentContext(DbContextOptions<PastAppointmentContext> options) : base(options)
        {
        }
        public DbSet<PastAppointment> PastAppointments { get; set; }
    }
}
