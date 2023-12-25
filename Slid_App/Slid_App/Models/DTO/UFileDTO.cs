using System.ComponentModel.DataAnnotations;

namespace Slid_App.Models.DTO
{
    public class UFileDTO
    {
        [Required]
        public int Id { get; set; }


        public User User { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string? VideoUrl { get; set; }
    }
}
