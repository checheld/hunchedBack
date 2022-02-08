using System.ComponentModel.DataAnnotations;

namespace hunchedDogBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? First_name { get; set; }
        [MaxLength(30)]
        public string? Last_name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(50)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        [MaxLength(30)]

        public List<Post>? Posts { get; set; } = new List<Post>();
    }
}
