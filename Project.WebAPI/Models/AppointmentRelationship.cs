using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebAPI.Models
{
    public class AppointmentRelationship
    {
        [Key]
        public int AppointmentRelationshipId { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        
    }
}
