using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;

    public EmployeeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
      _context = context;
      _userManager = userManager;
      _user = contextAccessor.HttpContext.User;
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<ActionResult> Post([FromForm] int ideaId, [FromForm] string postition, [FromForm] string name)
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var idea = await _context.Ideas
        .FindAsync(ideaId);

      if (idea != null) 
      {
        if (user.Site.SiteId == idea.SiteId) 
        {
          var employee = new Employee
          {
            Position = postition,
            Name = name
          };

          await _context.Entry(idea)
          .Collection(i => i.Employees)
          .LoadAsync();

          idea.Employees.Add(employee);

          await _context.SaveChangesAsync();

          return new EmptyResult();
        }
        else{

          return Unauthorized();
        }
      }

      return NotFound();
    }
  }
}
