using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EskobInnovation.IdeaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] List<IFormFile> files) 
        {
            Idea idea = await _context.Ideas.FirstOrDefaultAsync();
            
            foreach (var file in files)
            {
                Models.File f = new Models.File();
                f.Idea = idea;
                f.IdeaId = idea.IdeaId;
                f.Name = file.Name;
                using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        f.Data = ms.ToArray();
                    }
                _context.Files.Add(f);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}