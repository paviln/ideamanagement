using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
