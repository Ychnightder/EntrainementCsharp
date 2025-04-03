using Microsoft.AspNetCore.Mvc;
using Todo;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<TodoService>();

var app = builder.Build();


app.MapGet("/todos", ([FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.getAll());
});

app.MapGet("/todos/active", ([FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.getTodoActives());
});

app.MapGet("/todos/{id}", ([FromRoute] int id ,[FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.getTodoById(id));
});




app.MapPost("/todos", ([FromBody] string title, [FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.AddTodo(title));

});

// app.MapDelete("/todos/{id:int}", ([FromRoute] int id, [FromServices] TodoService todoService) =>
// {
//     todoService.RemoveTodo(id);
//     return Results.NoContent();
// });



app.MapPut("/todos/{id:int}", ([FromRoute] int id, [FromBody] Todo.Todo todo, [FromServices] TodoService todoService) =>
{
    todoService.UpdateTodo(id,todo);
    return Results.NoContent();
});

app.Run();
