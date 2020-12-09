using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string StreetAdresse { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string ContactPerson { get; set; }

    }
}
