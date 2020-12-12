using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class IdeaComment
  {
    public int IdeaCommentId { get; set; }
    [Required]
    public string Text { get; set; }
    public Idea Idea { get; set; }
  }
}