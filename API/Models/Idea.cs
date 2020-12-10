using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
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
        public string EmployeeNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public ICollection<Hashtag> Hashtags { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public ICollection<File> Files { get; set; }
    }
}