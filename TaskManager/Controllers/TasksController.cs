using System;
using System.Collections.Generic;
using System.Linq; // For querying
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Controllers
{

    // endpoint reached at:
    [Route("api/[controller]")]
    [ApiController]


    public class TasksController: ControllerBase
    {

        private readonly TaskContext _context; // a connection to the DB

        public TasksController(TaskContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetTasks()
        {
            var tasks = await _context.Tasks
                .Select(task => new
                {
                    task.Id,
                    task.Title,
                    task.Description,
                    Status = task.Status.ToString().Replace('_', ' '),
                    task.CreatedAt,
                    task.DueDate
                })
                .ToListAsync();

            return Ok(tasks);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetTaskItem(int id)
        {
            var taskItem = await _context.Tasks
                .Where(task => task.Id == id)
                .Select(task => new
                {
                    task.Id,
                    task.Title,
                    task.Description,
                    Status = task.Status.ToString().Replace('_', ' '),
                    task.CreatedAt,
                    task.DueDate
                })
                .FirstOrDefaultAsync();

            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }


        [HttpPost] 
        public async Task<ActionResult<TaskItem>> PostTaskItem([FromBody] TaskItem taskItem)
        {
            if (!ModelState.IsValid) 
            {
                Console.WriteLine("WE ARE INSIDE POST API BADREQUEST!!!!");
                return BadRequest(ModelState); 
            }

            Console.WriteLine("WE ARE INSIDE POST API");
            Console.WriteLine($"Status: {taskItem.Status}"); // Log the status value

            _context.Tasks.Add(taskItem); 
            await _context.SaveChangesAsync(); 

            // Log other values
            Console.WriteLine($"Task Id: {taskItem.Id}");
            Console.WriteLine($"Task Description: {taskItem.Description}");
            Console.WriteLine($"Task Due Date: {taskItem.DueDate}");

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem){
            if (id != taskItem.Id)
            {   
                return BadRequest();
            }

            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tasks.Any(e => e.Id == id))
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id){
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskItem);
            await _context.SaveChangesAsync(); // 

            return NoContent(); // returning nothing. 
        }

    }
}