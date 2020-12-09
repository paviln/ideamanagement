using EskobInnovation.IdeaManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public enum RegistrationResult
    {
        Success,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    public interface IAccountService
    {
        Task<Uri> CreateApplicationUserAccount(string email, string password);
    }
}
