using System.ComponentModel.DataAnnotations;

namespace Slid_App.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string DateOfBerth { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string ImageBase64 { get; set; }

        public List<Slid>? Slids { get; set; }

        public List<UFile>? Files { get; set; }
    }
}
