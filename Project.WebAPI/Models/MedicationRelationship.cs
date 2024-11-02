using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebAPI.Models
{
    public class MedicationRelationship
    {
        [Key]
        public int MedicationRelationshipId { get; set; }

        [ForeignKey(nameof(MedicalCard))]
        public int MedicalCardId { get; set; }

        [ForeignKey(nameof(Medication))]
        public int MedicationId { get; set; }
        

    }
}
