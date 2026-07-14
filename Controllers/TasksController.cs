using Microsoft.AspNetCore.Mvc;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTasks() 
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id) 
        {
            var task = _context.Tasks.Find(id);
            if(task == null){return NotFound();}

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new {id = newTask.Id}, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updatedTask)
        {
             if(id != updatedTask.Id)
             {return BadRequest("The IDs don't match");} // Check for id matches. URL-JSON

             var existingTask = _context.Tasks.Find(id);
             
             if(existingTask == null)
             {return NotFound("There is no task associated with this ID.");} // Check for is task absent.

             existingTask.Title = updatedTask.Title;
             existingTask.Description = updatedTask.Description;
             existingTask.IsDone = updatedTask.IsDone;

             _context.SaveChanges();

             return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.Find(id);

            if (taskToDelete == null)
            { return NotFound("There is no task associated with this ID.");} // Check for is task absent.

            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}