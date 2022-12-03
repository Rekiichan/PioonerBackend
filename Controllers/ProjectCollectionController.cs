using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pioneer_Backend.DataAccess.Data;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCollectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectCollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectCollection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCollection>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/ProjectCollection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCollection>> GetProjectCollection(int id)
        {
            var projectCollection = await _context.Projects.FindAsync(id);

            if (projectCollection == null)
            {
                return NotFound();
            }

            return projectCollection;
        }

        // PUT: api/ProjectCollection/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectCollection(int id, ProjectCollection projectCollection)
        {
            if (id != projectCollection.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectCollectionExists(id))
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

        // POST: api/ProjectCollection
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectCollection>> PostProjectCollection(ProjectCollection projectCollection)
        {
            _context.Projects.Add(projectCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectCollection", new { id = projectCollection.Id }, projectCollection);
        }

        // DELETE: api/ProjectCollection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectCollection(int id)
        {
            var projectCollection = await _context.Projects.FindAsync(id);
            if (projectCollection == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectCollectionExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
