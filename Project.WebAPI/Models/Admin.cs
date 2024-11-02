using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Models
{
    public class Admin
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
