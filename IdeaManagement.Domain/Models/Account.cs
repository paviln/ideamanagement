using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Domain Model
/// Representing 
/// Account Objects
/// </summary>
namespace IdeaManagement.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public Manager Manager { get; set; }

    }
}
