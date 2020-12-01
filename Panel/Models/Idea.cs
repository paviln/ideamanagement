using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Panel.Models
{
    public class Idea
    {
        public int IdeaId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Effort { get; set; }
        [Required]
        public string Impact { get; set; }
        [Required]
        public ICollection<File> Files { get; set; }
    }
}