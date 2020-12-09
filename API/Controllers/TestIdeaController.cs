using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestIdeaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestIdeaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TestIdea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idea>>> GetIdeas()
        {
            return await _context.Ideas.ToListAsync();
        }

        // GET: api/TestIdea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idea>> GetIdea(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);

            if (idea == null)
            {
                return NotFound();
            }

            return idea;
        }

        // PUT: api/TestIdea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdea(int id, Idea idea)
        {
            if (id != idea.IdeaId)
            {
                return BadRequest();
            }

            _context.Entry(idea).State = EntityState.Modified;

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

        // POST: api/TestIdea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Idea>> PostIdea(Idea idea)
        {
            _context.Ideas.Add(idea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdea", new { id = idea.IdeaId }, idea);
        }

        // DELETE: api/TestIdea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdea(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return NotFound();
            }

            _context.Ideas.Remove(idea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaExists(int id)
        {
            return _context.Ideas.Any(e => e.IdeaId == id);
        }
    }
}
