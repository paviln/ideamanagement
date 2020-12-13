using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EskobInnovation.IdeaManagement.API.Enums;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Task
  {
    public int TaskId { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public Employee Employee { get; set; }
    public Idea Idea { get; set; }
    public DateTime Date { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public ICollection<TaskComment> TaskComments { get; set; }
  }
}