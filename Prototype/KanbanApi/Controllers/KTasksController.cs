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
    public class KTasksController : ControllerBase
    {
        private readonly KanbanApiContext _context;

        public KTasksController(KanbanApiContext context)
        {
            _context = context;
        }

        // GET: api/KTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KTask>>> GetAllTasks()
        {
            return await _context.KTasks.ToListAsync();
        }

        // GET: api/KTasks/columnId
        [HttpGet("{columnId}")]
        public async Task<ActionResult<IEnumerable<KTask>>> GetKTasks(string columnId)
        {
            List<KTask> tasks = await _context.KTasks
                .Where(u => u.KColumnId == columnId)
                .ToListAsync();

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }
       
        // PUT: api/KTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKTask(string id, KTask kTask)
        {
            if (id != kTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(kTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KTaskExists(id))
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

        // POST: api/KTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KTask>> PostKTask(KTask kTask)
        {
            _context.KTasks.Add(kTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KTaskExists(kTask.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKTask", new { id = kTask.Id }, kTask);
        }

        // DELETE: api/KTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKTask(string id)
        {
            var kTask = await _context.KTasks.FindAsync(id);
            if (kTask == null)
            {
                return NotFound();
            }

            _context.KTasks.Remove(kTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KTaskExists(string id)
        {
            return _context.KTasks.Any(e => e.Id == id);
        }
    }
}
