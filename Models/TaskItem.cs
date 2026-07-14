using System.ComponentModel;

namespace TaskManagmentAPI.Models
{
    public class TaskItem
    {
        public int Id {get;set;}
        public string Title {get; set;}
        public string Description {get;set;}
        public bool IsDone {get;set;}
        public DateTime CreateDate {get;set;} = DateTime.Now; // Default created time.
    }
}