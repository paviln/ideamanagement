using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Panel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
