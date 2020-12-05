using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Panel.Data;
using Panel.Models;

namespace Panel.Controllers
{
  [Authorize(AuthenticationSchemes = "Identity.Application")]
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
  }
}