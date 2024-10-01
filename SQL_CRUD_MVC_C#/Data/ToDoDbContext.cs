using Microsoft.EntityFrameworkCore;
using SQL_CRUD_MVC_C_.Models;

namespace SQL_CRUD_MVC_C_.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<SQL_CRUD_MVC_C_.Models.TaskToDo> TaskToDo { get; set; } = default!;
    }
}
