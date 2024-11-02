using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;

namespace Project.WebAPI.Models.Contexts
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
