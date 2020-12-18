using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Site
  {
    public int SiteId { get; set; }
    [Required]
    public string Link { get; set; }
    public string StreetAddress { get; set; }
    [Required]
    public string ZipCode { get; set; }
    [Required]
    public string City { get; set; }
  
    public ICollection<Idea> Ideas { get; set; }
    public Customer Customer { get; set; }
  }
}