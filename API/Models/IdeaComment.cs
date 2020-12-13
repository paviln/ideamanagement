using System;
using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class IdeaComment
  {
    public int IdeaCommentId { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
    public Idea Idea { get; set; }
  }
}