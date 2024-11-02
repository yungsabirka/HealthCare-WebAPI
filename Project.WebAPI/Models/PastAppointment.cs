
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebAPI.Models
{
    public class PastAppointment
    {
        [Key]
        public int PastAppointmentKey {  get; set; }
        public DateTime DeletedTime { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public DateTime StartTime { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
