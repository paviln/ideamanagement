using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices
{
  public enum RegistrationResult
  {
    Success,
    EmailAlreadyExists
  }
  public interface IRegistrationService
  {
    Task<RegistrationResult> Register(string email, string password, string name, string position, int siteid);
  }
}
