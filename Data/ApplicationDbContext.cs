using Microsoft.EntityFrameworkCore;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<TaskItem> Tasks {get;set;}
    }
}