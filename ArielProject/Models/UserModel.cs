using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArielProject.Models
{

    [Table("user")]
    public class UserModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required, NotNull]
        public required string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;




    }
}
