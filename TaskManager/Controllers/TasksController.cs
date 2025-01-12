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
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks(){
            Console.WriteLine("WE ARE GETTING ALL THE TASKS");
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(int id){
            var taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        [HttpPost] // create a new record
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem){
            Console.WriteLine("WE ARE INSIDE POST API");


            _context.Tasks.Add(taskItem); //adding
            await _context.SaveChangesAsync(); //waiting for changes "making it official"

            // The response returns a 201 Created status, a link to the task, and the task data itself.
            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem){
            if (id != taskItem.Id)
            {   

                Console.WriteLine("id");
                Console.WriteLine(id);
                Console.WriteLine("taskITem");
                Console.WriteLine(taskItem.Id);
                Console.WriteLine("WE GOT A BAD REQUEST IDS DONT MATCH");
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