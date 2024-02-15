using TodoList.Models;

namespace TodoList.Tests;

public class TodoItemTest
{
    [Fact]
    public void SetAndGetId()
    {
        var item = new ToDoItem
        {
            Id = 1
        };

        Assert.Equal(1, item.Id);
    }

    [Fact]
    public void SetAndGetDueDate()
    {
        var item = new ToDoItem
        {
            DueDate = DateTime.MinValue
        };

        Assert.Equal(DateTime.MinValue, item.DueDate);
    }

    [Fact]
    public void SetAndGetCompletedDate()
    {
        var item = new ToDoItem
        {
            CompletedDate = DateTime.MaxValue
        };

        Assert.Equal(DateTime.MaxValue, item.CompletedDate);
    }

    [Fact]
    public void SetAndGetDescription()
    {
        string discription = "This is a description of an item";
        var item = new ToDoItem
        {
            Description = discription
        };

        Assert.Equal(discription, item.Description);
    }
}