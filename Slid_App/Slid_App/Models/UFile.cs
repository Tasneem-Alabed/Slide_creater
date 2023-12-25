using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slid_App.Models
{
    public class UFile
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string? VideoUrl { get; set; }
    }
}
