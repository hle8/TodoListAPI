namespace TodoList.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public DateTime? DueDate { get; set; } = null;
    public DateTime? CompletedDate { get; set; } = null;
    public string? Description { get; set; }
}
