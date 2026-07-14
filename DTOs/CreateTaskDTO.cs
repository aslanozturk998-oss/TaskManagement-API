using System.ComponentModel.DataAnnotations;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.DTOs
{
    public class CreateTaskDTO
    {
        [Required(ErrorMessage = "Tasks must contain a title.")]
        [MaxLength(100, ErrorMessage ="Title can be max 100 characters.")]
        public string Title {get;set;}

        [MaxLength(500)]
        public string Description {get;set;}

        public int CategoryId {get;set;}
    }
}