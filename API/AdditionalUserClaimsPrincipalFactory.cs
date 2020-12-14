using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using EskobInnovation.IdeaManagement.API.Models;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using EskobInnovation.IdeaManagement.API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EskobInnovation.IdeaManagement.API
{
  public class AdditionalUserClaimsPrincipalFactory
      : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    public AdditionalUserClaimsPrincipalFactory(
      ApplicationDbContext context,
      UserManager<ApplicationUser> userManager,
      RoleManager<IdentityRole> roleManager,
      IOptions<IdentityOptions> optionsAccessor)
      : base(userManager, roleManager, optionsAccessor)
    {
      _context = context;
      _userManager = userManager;
    }

    public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    {
      
      var userSite =_userManager.Users
        .Include(u => u.Site)
        .SingleAsync();
      var principal = await base.CreateAsync(user);
      var test = user.Site.SiteId;
      var site = await _context.Sites
        .Where(s => s.SiteId == user.Site.SiteId)
        .FirstOrDefaultAsync();
      
      var identity = (ClaimsIdentity)principal.Identity;

      var claims = new List<Claim>();
      claims.Add(new Claim(JwtClaimTypes.WebSite, user.Site.Link));

      identity.AddClaims(claims);
      return principal;
    }
  }
}