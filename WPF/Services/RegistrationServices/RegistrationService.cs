using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Service.SiteServices;
using EskobInnovation.IdeaManagement.WPF.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices
{
  public class RegistrationService : IRegistrationService
  {
    private readonly IApiAccountService _accountService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
    private readonly IApiSiteService _apiSiteService;
    public RegistrationService(IApiAccountService accountService, IPasswordHasher<ApplicationUser> passwordHasher, IApiSiteService apiSiteService)
    {
      _accountService = accountService;
      _passwordHasher = passwordHasher;
      _apiSiteService = apiSiteService;
    }
    public RegistrationService()
    {
      _apiSiteService = new ApiSiteService();
      _accountService = new ApiAccountService();
      _passwordHasher = new PasswordHasher<ApplicationUser>();
    }
    public async Task<RegistrationResult> Register(string email, string password, string name, string position, int siteid)
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
        var user = new ApplicationUser();
        var hashedPassword = _passwordHasher.HashPassword(user, password);

        Site site = await _apiSiteService.GetSiteByID(siteid);

        user = new ApplicationUser()
        {
          UserName = email,
          Email = email,
          PasswordHash = hashedPassword,
          EmailConfirmed = true,
          Site = site,
          Employee = new Employee()
          {
            Position = position,
            Name = name
          }
        };

       await _accountService.CreateApplicationUserAccount(user);
      }
      return result;
    }
  }
}
