using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slid_App.Models
{
    public class Slid
    {
        [Required]
        public int SlidId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        [Required]
        public string SlidName { get; set; }

        private string slidUrl;

        [Required]
        public string SlidUrl
        {
            get
            {
                if (string.IsNullOrEmpty(slidUrl))
                {
                    // Generate a random URL based on SlidId
                    slidUrl = $"/slides/{SlidId}/{GenerateRandomString()}";
                }
                return slidUrl;
            }
            set { slidUrl = value; }
        }

        private string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomChars = new char[8];
            Random random = new Random();

            for (int i = 0; i < randomChars.Length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomChars);
        }

        public List<Page> Page { get; set; }
    }
}