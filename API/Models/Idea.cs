using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EskobInnovation.IdeaManagement.API.Enums;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Idea
  {
    public int IdeaId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Effort { get; set; }
    [Required]
    public string Impact { get; set; }
    [Required]
    public string EmployeeNumber { get; set; }
    public DateTime Date { get; set; }
    public Status Status { get; set; }
    public string Challenge { get; set; }
    public string Result { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Hashtag> Hashtags { get; set; }
    public ICollection<IdeaComment> IdeaComments { get; set; }
    public ICollection<File> Files { get; set; }
    public int SiteId { get; set; }
    public Site Site { get; set; }
  }
}