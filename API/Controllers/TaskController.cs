using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class TaskController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;

    public TaskController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
      _context = context;
      _userManager = userManager;
      _user = contextAccessor.HttpContext.User;
    }

    // GET: api/Task/
    [HttpGet("{id}")]
    public async Task<ActionResult<List<EskobInnovation.IdeaManagement.API.Models.Task>>> GetTasks(int id)
    {
      var tasks = await _context.Tasks
        .Where(t => t.Idea.IdeaId == id)
        .ToListAsync();

        foreach (var item in tasks)
        {
          await _context.Entry(item)
          .Collection(t => t.TaskComments)
          .LoadAsync();

          await _context.Entry(item)
          .Reference(t => t.Employee)
          .LoadAsync();
        }

      return tasks;
    }

    // POST: api/Task
    [HttpPost]
    public async Task<ActionResult<IdeaComment>> Post([FromForm] int ideaId, [FromForm] string content)
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var idea = await _context.Ideas
        .FindAsync(ideaId);

      if (idea != null) 
      {
        if (user.Site.SiteId == idea.SiteId) 
        {
          var task = new EskobInnovation.IdeaManagement.API.Models.Task
          {
            Content = content,
            Employee = user.Employee,
            Idea = idea,
            Date = DateTime.Now,
            TaskStatus = EskobInnovation.IdeaManagement.API.Enums.TaskStatus.NotStarted,
          };

          idea.Tasks = new List<EskobInnovation.IdeaManagement.API.Models.Task>();

          idea.Tasks.Add(task);

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
