using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TaskManagementAPI.DTOs;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories // mapping
                .Select(c => new CategoryResponseDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO categoryDto)
        {
            var newCategory = new Category // mapping
            {
                Name = categoryDto.Name
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return Ok(new { Message = "Category successfully added.", CategoryId = newCategory.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("There is no category associated with this ID.");
            }
        
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}