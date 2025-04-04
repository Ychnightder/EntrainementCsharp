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


app.MapGet("/todos/{id:int}", ([FromRoute] int id ,[FromServices] TodoService todoService) =>
{
    var todo = todoService.getTodoById(id);
    if (todo == null) return Results.NotFound();
    return Results.Ok(todo);
});


app.MapGet("/todos/active", ([FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.getTodoActives());
});






app.MapPost("/todos", ([FromBody] string todo, [FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.AddTodo(todo));
});

 app.MapDelete("/todos/{id:int}", ([FromRoute] int id, [FromServices] TodoService todoService) =>
 {
   var res =  todoService.RemoveTodo(id);
    return res ?  Results.NoContent()  :  Results.NotFound();
 });



app.MapPut("/todos/{id:int}", ([FromRoute] int id, [FromBody] TodoDto todo, [FromServices] TodoService todoService) =>
{
    todoService.UpdateTodo(id,todo);
    return Results.NoContent();
});

app.Run();
