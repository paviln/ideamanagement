using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EskobInnovation.IdeaManagement.API.Attributes;
using System;

namespace EskobInnovation.IdeaManagement.API.Controllers
{
  [ApiKey]
  [ApiController]
  [Route("api/[controller]")]
  public class ApplicationUserController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    [HttpGet("getsite")]
    public async Task<ActionResult<ApplicationUser>> GetSite() 
    {
      var currentUser = await _userManager.GetUserAsync(HttpContext.User);
      await _context.Entry(currentUser).Reference(u => u.Site).LoadAsync();

      return currentUser;
    }

    [HttpPost("createuser")]
    public async Task<ActionResult<IdentityResult>> CreateUser(ApplicationUser user)
    {
      var result = await _userManager.CreateAsync(user);
      
      return result;
    }
  }
}