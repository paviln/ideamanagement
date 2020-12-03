using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Panel.Models
{
    public class Site
    {
        public int SiteId { get; set; }
        [Required]
        public string Link { get; set; }
        public ICollection<Idea> Ideas { get; set; }
    }
}