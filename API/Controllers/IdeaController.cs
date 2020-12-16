using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EskobInnovation.IdeaManagement.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IdeaController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;
    public IdeaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
      _context = context;
      _userManager = userManager;
      _user = contextAccessor.HttpContext.User;
    }

    // POST: api/Idea/getideasperiod
    [HttpPost("getideasperiod")]
    public async Task<ActionResult<IEnumerable<Idea>>> GetIdeasPeriod([FromForm] string link, [FromForm] String period)
    {
      var p = JsonConvert.DeserializeObject<List<DateTime>>(period);
      var ideas = await _context.Ideas
        .Where(i => (i.Date >= p[0] && i.Date <= p[1]) && (i.Site.Link == link))
        .ToListAsync();

      return ideas;
    }

    // GET: api/Idea/GetPeriod
    [HttpGet("getperiod")]
    public async Task<ActionResult<List<DateTime>>> GetPeriod(string link)
    {
      DateTime firstDate = await _context.Ideas
        .Where(i => i.Site.Link == link)
        .MinAsync(i => i.Date);

      DateTime lastDate = await _context.Ideas
        .Where(i => i.Site.Link == link)
        .MaxAsync(i => i.Date);

      List<DateTime> dateTimes = new List<DateTime>();
      dateTimes.Add(firstDate);
      dateTimes.Add(lastDate);

      return (dateTimes);
    }

    // GET: api/Idea/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Idea>> GetIdea(string link, int id)
    {
      var idea = await _context.Ideas.FindAsync(id);

      if (idea == null)
      {
        return NotFound();
      }

      await _context.Entry(idea)
        .Reference(i => i.Site)
        .LoadAsync();

      if (idea.Site.Link == link)
      {
        var tasks = await _context.Tasks
          .Where(t => t.Idea.IdeaId == idea.IdeaId)
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

        idea.Tasks = tasks;

        await _context.Entry(idea)
          .Collection(i => i.Tasks)
          .LoadAsync();

        await _context.Entry(idea)
          .Collection(i => i.Employees)
          .LoadAsync();

        await _context.Entry(idea)
        .Reference(i => i.Site)
        .LoadAsync();

        await _context.Entry(idea)
         .Collection(i => i.Files)
         .LoadAsync();

        await _context.Entry(idea)
          .Collection(i => i.Hashtags)
          .LoadAsync();

        await _context.Entry(idea)
        .Collection(i => i.IdeaComments)
        .LoadAsync();

        return idea;
      }

      return Unauthorized();
    }

    // GET: api/Idea/GetSiteIdeas
    [HttpGet("getsiteideas")]
    public async Task<ActionResult<IEnumerable<Idea>>> GetSiteIdeas(string link)
    {
      var ideas = await _context.Ideas
        .Where(i => i.Site.Link == link)
        .ToListAsync();

      return ideas;
    }

    // GET: api/Idea/GetUserIdeas
    [Authorize]
    [HttpGet("getuserideas")]
    public async Task<ActionResult<IEnumerable<Idea>>> GetUserIdeas()
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var ideas = await _context.Ideas
        .Where(i => i.Site.Link == user.Site.Link)
        .ToListAsync();

      foreach (var idea in ideas)
      {
        await _context.Entry(idea)
        .Reference(i => i.Site)
        .LoadAsync();
      }

      return ideas;
    }

    // GET: api/Idea/GetUserIdeasWithStatus
    [Authorize]
    [HttpGet("getuserideaswithstatus")]
    public async Task<ActionResult<IEnumerable<Idea>>> GetUserIdeasWithStatus(int status)
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var ideas = await _context.Ideas
        .Where(i => i.Site.Link == user.Site.Link && i.Status == (Enums.Status)status)
        .ToListAsync();

      foreach (var idea in ideas)
      {
        await _context.Entry(idea)
        .Reference(i => i.Site)
        .LoadAsync();
      }

      return ideas;
    }

    // GET: api/Idea/GetIdeaFileData
    [HttpGet("Getideafiledata")]
    public async Task<ActionResult> GetIdeaFileData(string link, int fileId)
    {
      var file = await _context.Files
        .Where(f => f.FileId == fileId)
        .FirstOrDefaultAsync();

      if (file != null)
      {
        var fileData = await _context.FileDatas
          .Where(fd => fd.FileId == fileId)
          .FirstOrDefaultAsync();

        if (fileData != null)
        {

          return File(fileData.Data, file.Type);
        }
      }

      return NotFound();
    }

    // PUT: api/Idea/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIdea(int id, Idea idea)
    {
      var userId = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(userId);

      var entity = await _context.Ideas
        .FindAsync(id);

      if (id != entity.IdeaId)
      {
        return NotFound();
      }

      await _context.Entry(entity)
        .Reference(i => i.Site)
        .LoadAsync();

      if (user.Site.Link == entity.Site.Link)
      {
        _context.Entry(entity).CurrentValues.SetValues(idea);
        _context.Entry(entity).State = EntityState.Modified;

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!IdeaExists(id))
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

    // POST: api/Idea
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Idea>> PostIdea([FromForm] Idea idea, [FromForm] List<IFormFile> files, [FromForm] List<String> hashtags)
    {
      idea.Files = new List<Models.File>();
      foreach (var element in files)
      {
        if (element != null)
        {
          try
          {
            Models.File file = new Models.File();
            file.IdeaId = idea.IdeaId;
            file.Name = element.FileName;
            file.Type = element.ContentType;
            FileData fileData = new FileData();
            using (var ms = new MemoryStream())
            {
              element.CopyTo(ms);
              fileData.Data = ms.ToArray();
            }
            file.FileData = fileData;
            idea.Files.Add(file);
          }
          catch (System.Exception error)
          {
            System.Console.WriteLine(error);
          }
        }
      }

      idea.Hashtags = new List<Hashtag>();
      foreach (var element in hashtags)
      {
        if (!element.IsNullOrEmpty())
        {
          var hashtag = await _context.Hashtags
          .Where(h => h.Name == element)
          .FirstOrDefaultAsync();

          if (hashtag != null)
          {
            idea.Hashtags.Add(hashtag);
          }
          else
          {
            Hashtag h = new Hashtag();
            h.Name = element;
            idea.Hashtags.Add(h);
          }
        }
      }

      _context.Ideas.Add(idea);

      await _context.SaveChangesAsync();

      return CreatedAtAction("GetIdea", new { id = idea.IdeaId }, idea);
    }

    // DELETE: api/Idea/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Idea>> DeleteIdea(int id)
    {
      var userId = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(userId);

      var idea = await _context.Ideas.FindAsync(id);
      if (idea == null)
      {
        return NotFound();
      }

      await _context.Entry(idea)
        .Reference(i => i.Site)
        .LoadAsync();

      if (idea.Site.Link == user.Site.Link)
      {
        _context.Ideas.Remove(idea);
        await _context.SaveChangesAsync();

        return idea;
      }

      return Unauthorized();
    }

    private bool IdeaExists(int id)
    {
      return _context.Ideas.Any(e => e.IdeaId == id);
    }
  }
}
