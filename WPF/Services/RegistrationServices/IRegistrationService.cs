using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices
{
  public enum RegistrationResult
  {
    Success,
    EmailAlreadyExists
  }
  public interface IRegistrationService
  {
    Task<RegistrationResult> Register(string email, string password);
  }
}
