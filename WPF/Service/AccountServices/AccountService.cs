using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public class AccountService : IAccountService
    {
        private static ApiHelper client = new ApiHelper();

        public AccountService() { }

        public async Task<Uri> CreateApplicationUserAccount(string email, string password)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                PasswordHash = password
            };
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/applicationuser", user);
            return response.Headers.Location;
        }
    }
}
