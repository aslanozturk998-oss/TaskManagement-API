using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class Category
    {
        public int Id {get;set;}

        [Required(ErrorMessage ="Category must contain a name.")]
        [MaxLength(50)]
        public string Name {get;set;}
        public List<TaskItem> Tasks {get;set;} // 1-N Relation Connection
    }
}