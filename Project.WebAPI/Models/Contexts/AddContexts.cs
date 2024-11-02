using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class AddContexts
    {
        public static void AddContextForModels(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<UserContext>(options => options
                   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppointmentContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<MedicalCardContext>(options => options
                   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<MedicationContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<DoctorContext>(options => options
                   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AdminContext>(options => options
                   .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppointmentRelationshipContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<MedicationRelationshipContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppointmentContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<PastAppointmentContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
