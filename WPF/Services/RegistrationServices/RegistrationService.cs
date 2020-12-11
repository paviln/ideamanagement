using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using Microsoft.AspNetCore.Identity;

namespace EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices
{
  public class RegistrationService : IRegistrationService
  {
    private readonly IApiAccountService _accountService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

    public RegistrationService(IApiAccountService accountService, IPasswordHasher<ApplicationUser> passwordHasher )
    {
      _accountService = accountService;
      _passwordHasher = passwordHasher;
    }
    public RegistrationService()
    {
      _accountService = new ApiAccountService();
      _passwordHasher = new PasswordHasher<ApplicationUser>();
    }
    public async Task<RegistrationResult> Register(string email, string password)
    {
      RegistrationResult result = RegistrationResult.Success;      
      //ApplicationUser emailUser = await _accountService.GetByEmail(email);
      string testemail = null;
      if(testemail != null)
      {
        result = RegistrationResult.EmailAlreadyExists;
      }
      if(result == RegistrationResult.Success)
      {
        ApplicationUser user = new ApplicationUser();
        string hashedPassword = _passwordHasher.HashPassword(user, password);

        user = new ApplicationUser()
        {
          UserName = email,
          Email = email,
          PasswordHash = hashedPassword,
          EmailConfirmed = true
        };
        await _accountService.CreateApplicationUserAccount(user);
      }
      return result;
    }
  }
}
