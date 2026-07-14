using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagmentAPI.Models
{
    public class TaskItem
    {
        public int Id {get;set;}

        [Required(ErrorMessage ="Tasks must contain a title.")]
        [MaxLength(100, ErrorMessage ="Title can be max 100 characters.")]
        public string Title {get; set;}

        [MaxLength(500)]
        public string Description {get;set;}
        public bool IsDone {get;set;}
        public DateTime CreateDate {get;set;} = DateTime.Now; // Default created time.
    }
}