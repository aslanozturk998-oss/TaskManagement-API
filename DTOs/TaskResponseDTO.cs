namespace TaskManagementAPI.DTOs
{
    public class TaskResponseDTO
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public string Description{get;set;}
        public bool IsDone {get;set;}
        public DateTime CreateDate {get;set;}


        public string CategoryName {get;set;} // Just category name not the category object
    }
}