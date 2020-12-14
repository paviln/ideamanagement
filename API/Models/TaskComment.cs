using System;
using System.ComponentModel.DataAnnotations;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class TaskComment
  {
    public int TaskCommentId { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
    public Task Task { get; set; }
  }
}