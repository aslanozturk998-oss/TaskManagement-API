using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.DTOs;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.DTOs;
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
            var tasks = _context.Tasks // Mapping
                .Select(task => new TaskResponseDTO
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    IsDone = task.IsDone,
                    CreateDate = task.CreateDate,
                    CategoryName = task.Category != null ? task.Category.Name : "Uncategorized"
                })
                .ToList();
                return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id) 
        {
            var taskDto = _context.Tasks
                .Where(t => t.Id == id) // filter
                .Select(task => new TaskResponseDTO // mapping
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    IsDone = task.IsDone,
                    CreateDate = task.CreateDate,
                    CategoryName = task.Category != null ? task.Category.Name : "Uncategorized"

                })
                .FirstOrDefault();
                
                if(taskDto == null) {return NotFound("There is no task associated with this ID.");}

                return Ok(taskDto);
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskDTO taskDTO)
        {
            var newTask = new TaskItem // Mapping
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                CategoryId = taskDTO.CategoryId
            };
            
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return Ok(new {Message = "Task successfully added.", TaskId = newTask.Id});
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, UpdateTaskDTO taskDto)
        {
            var existingTask = _context.Tasks.Find(id);

            if(existingTask == null){ return NotFound("There is no task associated with this ID.");}

            // mapping
            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.CategoryId = taskDto.CategoryId;
            existingTask.IsDone = taskDto.IsDone;

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