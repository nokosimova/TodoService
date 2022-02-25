using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure.Persistense
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}