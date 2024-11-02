using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebAPI.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public bool Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey(nameof(MedicalCard))]
        public int MedicalCardId { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
