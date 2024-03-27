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
    public class KUsersController : ControllerBase
    {
        private readonly KanbanApiContext _context;

        public KUsersController(KanbanApiContext context)
        {
            _context = context;
        }
        // GET: api/KUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KUser>>> GetAllUsers()
        {
            return await _context.KUsers.ToListAsync();
        }
      
        // GET: api/KUsers/email
        [HttpGet("{email}")]
        public async Task<ActionResult<KUser>> GetKUser(string email)
        {
            
            //get the user from the database
            var kanbanUser = await _context.KUsers.FirstOrDefaultAsync(u => u.Email == email)
                ?? new KUser();

            if (kanbanUser.Email != "Blank Email")
            {

                kanbanUser.Workspaces = _context.KWorkspaces.Where(w => w.KUserId == kanbanUser.Id).ToList();
                kanbanUser.Workspaces.ForEach(w =>
                {
                    w.Boards = _context.KBoards.Where(b => b.KWorkspaceId == w.Id).ToList();
                    w.Boards.ForEach(b =>
                    {
                        b.Columns = _context.KColumns.Where(c => c.KBoardId == b.Id).ToList();
                        b.Columns.ForEach(c =>
                        {
                            c.Tasks = _context.KTasks.Where(t => t.KColumnId == c.Id).ToList();
                        });
                    });
                });
            }

            return kanbanUser;
        }

        // PUT: api/KUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKUser(string id, KUser kUser)
        {
            if (id != kUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(kUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KUserExists(id))
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

        // POST: api/KUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KUser>> PostKUser(KUser kUser)
        {
            _context.KUsers.Add(kUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KUserExists(kUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKUser", new { id = kUser.Id }, kUser);
        }

        // DELETE: api/KUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKUser(string id)
        {
            var kUser = await _context.KUsers.FindAsync(id);
            if (kUser == null)
            {
                return NotFound();
            }

            _context.KUsers.Remove(kUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KUserExists(string id)
        {
            return _context.KUsers.Any(e => e.Id == id);
        }
    }
}
