using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentRelationship> AppointmentRelationships { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalCard> MedicalCards { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationRelationship> MedicationRelationships { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PastAppointment> PastAppointments { get; set; }

    }
}
