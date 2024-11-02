using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }

        public string MedicationName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Contraindications { get; set; } = string.Empty;


    }
}
