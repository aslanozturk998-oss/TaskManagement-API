using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.DTOs
{
    public class UpdateTaskDTO
    {
        [Required(ErrorMessage = "Tasks must contain a title.")]
        [MaxLength(100, ErrorMessage ="Title can be max 100 characters.")]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool IsDone { get; set; }
    }
}