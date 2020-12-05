using System.ComponentModel.DataAnnotations;

namespace Panel.Models
{
  public class Hashtag
  {
    public int HashtagId { get; set; }
    [Required]
    public string Name { get; set; }
  }
}