using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slid_App.Models
{
    public class Page
    {
        public int Id { get; set; }

       
        public Slid Slids { get; set; }

        public int SlidId { get; set; }


        public string? Text { get; set; }

        [DataType(DataType.MultilineText)]
        public string? ImageBase64 { get; set; }

        [DataType(DataType.Url)]
        public string? VideoUrl { get; set; }
    }
}