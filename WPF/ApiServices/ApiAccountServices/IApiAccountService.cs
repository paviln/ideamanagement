using EskobInnovation.IdeaManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public interface IApiAccountService
  {
    Task<Uri> CreateApplicationUserAccount(ApplicationUser user);
    Task<ApplicationUser> GetByEmail(string email);
  }
}
