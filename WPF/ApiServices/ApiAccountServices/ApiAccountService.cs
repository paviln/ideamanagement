using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.ApiServices;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public class ApiAccountService : IApiAccountService
  {
    
    private static PrepHttpClient client = new PrepHttpClient();

    public ApiAccountService()  {  }

    public async Task<Uri> CreateApplicationUserAccount(ApplicationUser user)
    {
      HttpResponseMessage response = await client.PostAsJsonAsync("/api/applicationuser/createuser", user);
      return response.Headers.Location;
    }

    public async Task<ApplicationUser> GetByEmail(string email)
    {
      string url = "/api/aplicationuser/";
      ApplicationUser user = null;
      HttpResponseMessage response = await client.GetAsync(url);
      if (response.IsSuccessStatusCode)
      {
        user = await response.Content.ReadAsAsync<ApplicationUser>();
      }
      return user;
    }
  }
}
