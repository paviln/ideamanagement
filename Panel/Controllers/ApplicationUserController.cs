using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using Panel.Data;
using Panel.Models;

namespace Panel.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ApplicationUserController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public ApplicationUserController(ApplicationDbContext context)
    {
        _context = context;
    }

        // GET: api/ApplicationUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
  }
}