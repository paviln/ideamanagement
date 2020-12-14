using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class Employee
  {
    public int EmployeeId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Position { get; set; }
    public ICollection<Idea> Ideas { get; set; }
  }
}
