using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

    }
}
