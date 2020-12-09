using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        
        private static ApiHelper client = new ApiHelper();

        public AccountService(IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public AccountService() 
        {
            _passwordHasher = new PasswordHasher<ApplicationUser>();
        }
        public async Task<Uri> CreateApplicationUserAccount(string email, string password)
        {
            ApplicationUser user = new ApplicationUser();

            var hashedPassword = _passwordHasher.HashPassword(user, password);

            

            user = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                PasswordHash = hashedPassword,
                EmailConfirmed = true              
            };
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/applicationuser/createuser", user);
            return response.Headers.Location;
        }
    }
}
