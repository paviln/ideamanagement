using System;
using System.ComponentModel.DataAnnotations;
using EskobInnovation.IdeaManagement.API.Extenstions;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class IdeaComment
  {
    private Employee _employee;
    public IdeaComment()
    { }
    private IdeaComment(Action<object, string> lazyLoader)
    {
      LazyLoader = lazyLoader;
    }
    private Action<object, string> LazyLoader { get; set; }
    public int IdeaCommentId { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public Employee Employee 
    {
      get => LazyLoader.Load(this, ref _employee);
      set => _employee = value;
    }
    public DateTime Date { get; set; }
    public Idea Idea { get; set; }
  }
}