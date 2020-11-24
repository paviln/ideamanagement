using System.ComponentModel.DataAnnotations;

namespace Panel.Models
{
    public class Idea
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Effort { get; set; }
        [Required]
        public string Impact { get; set; }
    }
}