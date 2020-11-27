using System.ComponentModel.DataAnnotations;

namespace Panel.Models
{
    public class Site
    {
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
    }
}