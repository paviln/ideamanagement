using System.ComponentModel.DataAnnotations;
/// <summary>
/// Domain Model
/// Representing 
/// Idea Objects
/// </summary>
namespace IdeaManagement.Domain.Models
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
