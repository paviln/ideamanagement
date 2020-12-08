using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHasher _passwordHasher;

        private static ApiHelper client = new ApiHelper();

        public AccountService(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public AccountService() 
        {
            _passwordHasher = new PasswordHasher();
        }
        public async Task<Uri> CreateApplicationUserAccount(string email, string password)
        {
            var hashedPassword =_passwordHasher.HashPassword(password);

            ApplicationUser user = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                PasswordHash = hashedPassword  
            };
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/applicationuser", user);
            return response.Headers.Location;
        }
    }
}
