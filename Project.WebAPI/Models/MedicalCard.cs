using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Models
{
    public class MedicalCard
    {
        [Key]
        public int MedicalCardId { get; set; }

        public string Diseases { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Treatment {  get; set; } = string.Empty;

        public string TestResults { get; set; } = string.Empty;

    }
}
