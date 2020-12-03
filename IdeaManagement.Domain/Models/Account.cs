using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Account Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Account : DomainObject
    {
        [Required]
        public Manager Manager { get; set; }

    }
}
