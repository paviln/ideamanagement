using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

using Panel.Models;
using Panel.Data;

namespace Panel.Controllers
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
        public async Task<ActionResult> Post([FromForm] FileModel file) 
        {
            Idea idea = new Idea();
            
            Models.File file1 = new Models.File();
            file1.Name = file.FileName;
            using (var ms = new MemoryStream())
                {
                    file.FormFile.CopyTo(ms);
                    file1.Data = ms.ToArray();
                }
            _context.Files.Add(file1);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}