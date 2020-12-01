using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Manager Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Manager : DomainObject
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// PW needs to be encrypted later
        /// </summary>
        public string Password { get; set; }
    }
}
