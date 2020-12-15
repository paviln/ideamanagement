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
  public class CommentController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;

    public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
      _context = context;
      _userManager = userManager;
      _user = contextAccessor.HttpContext.User;
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<ActionResult<IdeaComment>> Post([FromForm] int ideaId, [FromForm] string content)
    {
      var id = _user.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.FindByIdAsync(id);

      var idea = await _context.Ideas
        .FindAsync(ideaId);

      var comment = new IdeaComment
      {
        Content = content,
        Employee = user.Employee,
        Date = DateTime.Now,
        Idea = idea
      };

      _context.IdeaComments.Add(comment);

      await _context.SaveChangesAsync();

      return comment;
    }
  }
}
