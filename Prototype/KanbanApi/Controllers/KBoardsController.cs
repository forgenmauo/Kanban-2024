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
    public class KBoardsController : ControllerBase
    {
        private readonly KanbanApiContext _context;

        public KBoardsController(KanbanApiContext context)
        {
            _context = context;
        }

        // GET: api/KBoards/workspaceId
        [HttpGet("{workspaceId}")]
        public async Task<ActionResult<IEnumerable<KBoard>>> GetKBoards(string workspaceId)
        {
            List<KBoard> boards = await _context.KBoards
                .Where(u => u.KWorkspaceId == workspaceId)
                .ToListAsync();

            if (boards == null)
            {
                return NotFound();
            }

            return boards;
        }
       
        // PUT: api/KBoards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKBoard(string id, KBoard kBoard)
        {
            if (id != kBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(kBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KBoardExists(id))
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

        // POST: api/KBoards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KBoard>> PostKBoard(KBoard kBoard)
        {
            _context.KBoards.Add(kBoard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KBoardExists(kBoard.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKBoard", new { id = kBoard.Id }, kBoard);
        }

        // DELETE: api/KBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKBoard(string id)
        {
            var kBoard = await _context.KBoards.FindAsync(id);
            if (kBoard == null)
            {
                return NotFound();
            }

            _context.KBoards.Remove(kBoard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KBoardExists(string id)
        {
            return _context.KBoards.Any(e => e.Id == id);
        }
    }
}
