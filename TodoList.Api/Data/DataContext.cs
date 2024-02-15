using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<ToDoItem> TodoItems { get; set; }
}
