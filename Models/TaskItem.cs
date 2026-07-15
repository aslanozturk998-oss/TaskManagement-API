using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        public int Id {get;set;}

        [Required(ErrorMessage ="Tasks must contain a title.")]
        [MaxLength(100, ErrorMessage ="Title can be max 100 characters.")]
        public string Title {get; set;}

        [MaxLength(500)]
        public string Description {get;set;}
        public bool IsDone {get;set;} // False by default
        public DateTime CreateDate {get;set;} = DateTime.Now; // Default created time.

        public int CategoryId {get;set;} // Category foreing key
        public Category Category {get;set;} // 1-N Relation connection
    }
}