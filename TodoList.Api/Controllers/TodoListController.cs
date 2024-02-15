using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoList : ControllerBase
{
    private readonly DataContext _context;

    public TodoList(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ToDoItem>>> GetAllNotCompletedTodoItems()
    {
        var items = await _context.TodoItems
        .Where(item => item.CompletedDate == null)
        .ToArrayAsync();

        if (items is null)
            return BadRequest("Items not found!");

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<ToDoItem>>> GetTodoItemById(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if (item is null)
            return BadRequest("Item not found!");

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<List<ToDoItem>>> CreateTodoItem(ToDoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<List<ToDoItem>>> UpdateCurrentDateTodoItemById(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if (item is null)
            return BadRequest("Item not found!");
        item.CompletedDate = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok();
    }
}
