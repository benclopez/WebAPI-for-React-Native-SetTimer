using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SetTimerApi.Models;
using SetTimerAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetTimerApi.Controllers
{
    [Route("api/workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutContext _context;

        public WorkoutController(WorkoutContext context)
        {
            _context = context;

            if (_context.WorkoutItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.WorkoutItems.Add(new WorkoutItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutItem>>> GetWorkoutItems()
        {
            return await _context.WorkoutItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutItem>> GetWorkoutItem(long id)
        {
            var workoutItem = await _context.WorkoutItems.FindAsync(id);

            if (workoutItem == null)
            {
                return NotFound();
            }

            return workoutItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<WorkoutItem>> PostTodoItem(WorkoutItem item)
        {
            _context.WorkoutItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkoutItem), new { id = item.Id }, item);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutItem(long id)
        {
            var workoutItem = await _context.WorkoutItems.FindAsync(id);

            if (workoutItem == null)
            {
                return NotFound();
            }

            _context.WorkoutItems.Remove(workoutItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}