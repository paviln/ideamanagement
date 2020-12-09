using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Hashtag
  {
    public int HashtagId { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Idea> Ideas { get; set; }
  }
}