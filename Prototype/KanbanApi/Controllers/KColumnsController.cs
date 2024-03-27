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
    public class KColumnsController : ControllerBase
    {
        private readonly KanbanApiContext _context;

        public KColumnsController(KanbanApiContext context)
        {
            _context = context;
        }

        // GET: api/KColumns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KColumn>>> GetAllColumns()
        {
            return await _context.KColumns.ToListAsync();
        }

        // GET: api/KColumns/boardId
        [HttpGet("{boardId}")]
        public async Task<ActionResult<IEnumerable<KColumn>>> GetKColumns(string boardId)
        {
            List<KColumn> columns = await _context.KColumns
                .Where(u => u.KBoardId == boardId)
                .ToListAsync();

            if (columns == null)
            {
                return NotFound();
            }

            return columns;
        }
        
        // PUT: api/KColumns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKColumn(string id, KColumn kColumn)
        {
            if (id != kColumn.Id)
            {
                return BadRequest();
            }

            _context.Entry(kColumn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KColumnExists(id))
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

        // POST: api/KColumns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KColumn>> PostKColumn(KColumn kColumn)
        {
            _context.KColumns.Add(kColumn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KColumnExists(kColumn.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKColumn", new { id = kColumn.Id }, kColumn);
        }

        // DELETE: api/KColumns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKColumn(string id)
        {
            var kColumn = await _context.KColumns.FindAsync(id);
            if (kColumn == null)
            {
                return NotFound();
            }

            _context.KColumns.Remove(kColumn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KColumnExists(string id)
        {
            return _context.KColumns.Any(e => e.Id == id);
        }
    }
}
