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
        else
        {

          return Unauthorized();
        }
      }

      return NotFound();
    }

    // POST: api/Task
    [HttpPost("comment")]
    public async Task<ActionResult<IdeaComment>> SaveComment([FromForm] int taskId, [FromForm] string comment)
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var task = await _context.Tasks
        .FindAsync(taskId);

      if (task != null)
      {
        await _context.Entry(task)
          .Reference(t => t.Idea)
          .LoadAsync();

        if (user.Site.SiteId == task.Idea.SiteId)
        {
          var taskComment = new EskobInnovation.IdeaManagement.API.Models.TaskComment
          {
            Content = comment,
            Employee = user.Employee,
            Date = DateTime.Now,
            Task = task
          };

          task.TaskComments = new List<TaskComment>();

          task.TaskComments.Add(taskComment);

          await _context.SaveChangesAsync();

          return new EmptyResult();
        }
        else
        {

          return Unauthorized();
        }
      }

      return NotFound();
    }

    // PUT: api/Task/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, EskobInnovation.IdeaManagement.API.Models.Task task)
    {
      var userId = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(userId);

      var entity = await _context.Tasks
        .FindAsync(id);

      if (entity == null)
      {
        return NotFound();
      }

      await _context.Entry(entity)
        .Reference(t => t.Idea)
        .LoadAsync();

      if (user.Site.Link == entity.Idea.Site.Link)
      {
        _context.Entry(entity).CurrentValues.SetValues(task);
        _context.Entry(entity).State = EntityState.Modified;

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TaskExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

        return NoContent();
      }

      return Unauthorized();
    }
    private bool TaskExists(int id)
    {
      return _context.Tasks.Any(e => e.TaskId == id);
    }
  }
}
