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
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }

    }
}
