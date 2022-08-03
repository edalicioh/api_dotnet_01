
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Infra.Configuration;

namespace TodoList.Infra.Context
{
    public class TodoContext: DbContext
    {
        public TodoContext()
        {
            
        }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users {get; set;}

    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<User>(new UserConfiguration());
        }

    }
}