using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Category must contain a name.")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}