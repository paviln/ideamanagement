using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Site Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Site
    {
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
