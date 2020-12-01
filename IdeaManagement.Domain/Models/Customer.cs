using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Customer Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Customer : DomainObject
    {
        [Required]
        public string CustomerName { get; set; }

    }
}
