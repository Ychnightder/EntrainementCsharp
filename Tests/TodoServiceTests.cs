using Xunit;

namespace Todo.Tests;

public class TodoServiceTests
{
    [Fact]
    public void GetAllTodos()
    {
        var service = new TodoService();
        var result = service.getAll();
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetTodoById()
    {
        var service = new TodoService();
        var result = service.getTodoById(1);
        Assert.NotNull(result);
        Assert.Equal("Csharp", result.Title);

    }

    [Fact]
    public void AddTodoTests()
    {
        var service = new TodoService();
        var result = service.AddTodo("Test Todo");
        Assert.NotNull(result);
        Assert.Equal("Test Todo", result.Title);
    }

    [Fact]
    public void RemoveTodoTests()
    {
        var service = new TodoService();
        service.RemoveTodo(1);
        var result = service.getAll();
        Assert.Single(result);
    }
    [Fact]
    public void UpdateTodoTests()
    {
        var service = new TodoService();
        var todo = service.getTodoById(1);
        service.UpdateTodo(1,todo);
        var result = service.getTodoById(1);
        Assert.Equal("Updated Title", result.Title);
        Assert.True(result.EndDate > DateTime.Now);
    }
    [Fact]
    public void GetTodoActivesTests()
    {
        var service = new TodoService();
        var result = service.getTodoActives();
        Assert.Equal(2, result.Count);
    }
}
