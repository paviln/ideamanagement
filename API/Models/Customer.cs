using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Customer
  {
    public int Id { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string ContactPerson { get; set; }
    [Required]
    public string StreetAddress { get; set; }
    [Required]
    public string ZipCode { get; set; }
    [Required]
    public string City { get; set; }
    public ICollection<Site> Sites { get; set; }
  }
}
