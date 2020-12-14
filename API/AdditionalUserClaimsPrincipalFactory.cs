using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using EskobInnovation.IdeaManagement.API.Models;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;

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
      var principal = await base.CreateAsync(user);
      var identity = (ClaimsIdentity)principal.Identity;

      var claims = new List<Claim>();
      claims.Add(new Claim(JwtClaimTypes.WebSite, user.Site.Link));

      identity.AddClaims(claims);
      return principal;
    }
  }
}