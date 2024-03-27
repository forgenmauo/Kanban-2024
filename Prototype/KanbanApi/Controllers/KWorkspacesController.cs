using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using KanbanApi.Data;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KWorkspacesController : ControllerBase
    {
        private readonly KanbanApiContext _context;

        public KWorkspacesController(KanbanApiContext context)
        {
            _context = context;
        }

        // GET: api/KWorkspaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KWorkspace>>> GetAllWorkspaces()
        {
            return await _context.KWorkspaces.ToListAsync();
        }

        // GET: api/KWorkspaces/userId
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<KWorkspace>>> GetKWorkspaces(string userId)
        {
            List<KWorkspace> workspaces = await _context.KWorkspaces
                .Where(u => u.KUserId == userId)
                .ToListAsync();

            if (workspaces == null)
            {
                return NotFound();
            }

            return workspaces;

        }
        
        // PUT: api/KWorkspaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKWorkspace(string id, KWorkspace kWorkspace)
        {
            if (id != kWorkspace.Id)
            {
                return BadRequest();
            }

            _context.Entry(kWorkspace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KWorkspaceExists(id))
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

        // POST: api/KWorkspaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KWorkspace>> PostKWorkspace(KWorkspace kWorkspace)
        {
            _context.KWorkspaces.Add(kWorkspace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KWorkspaceExists(kWorkspace.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKWorkspace", new { id = kWorkspace.Id }, kWorkspace);
        }

        // DELETE: api/KWorkspaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKWorkspace(string id)
        {
            var kWorkspace = await _context.KWorkspaces.FindAsync(id);
            if (kWorkspace == null)
            {
                return NotFound();
            }

            _context.KWorkspaces.Remove(kWorkspace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KWorkspaceExists(string id)
        {
            return _context.KWorkspaces.Any(e => e.Id == id);
        }
    }
}
