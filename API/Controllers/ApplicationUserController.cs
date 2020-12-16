using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EskobInnovation.IdeaManagement.API.Attributes;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace EskobInnovation.IdeaManagement.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ApplicationUserController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;
    public ApplicationUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
      _context = context;
      _userManager = userManager;
      _user = contextAccessor.HttpContext.User;
    }

    // GET: api/ApplicationUser/GetSite
    [Authorize]
    [HttpGet("getsite")]
    public async Task<ActionResult<Site>> GetSite()
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      return user.Site;
    }

    // POST: api/ApplicationUser/CreateUser
    [ApiKey]
    [HttpPost("createuser")]
    public async Task<IdentityResult> CreateUser(ApplicationUser user)
    {
      var result = await _userManager.CreateAsync(user);

      return result;
    }
  }
}