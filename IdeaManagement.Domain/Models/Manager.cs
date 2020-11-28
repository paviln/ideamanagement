using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Manager Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        /// <summary>
        /// PW needs to be encrypted later
        /// </summary>
        public string Password { get; set; }
    }
}
