using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
    }
}
