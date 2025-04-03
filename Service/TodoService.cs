namespace Todo
{
    public class TodoService
    {
        private List<Todo> List_todoList = new List<Todo>()
        {
            new Todo {Id = 1 , Title = "Csharp"  },
            new Todo {Id = 2 , Title = "Lua" }
        };
        public List<Todo> getAll()
        {
            return List_todoList;
        }
        public Todo getTodoById(int id)
        {
            return List_todoList.Find(todo => todo.Id == id) ?? throw new InvalidOperationException("Todo not found");
        }
        public Todo AddTodo(string titre)
        {
            Todo todo = new Todo
            {
                Id = List_todoList.Max(todo => todo.Id) + 1,
                Title = titre,

            };
            List_todoList.Add(todo);
            return todo;
        }
        public void RemoveTodo(int id) => List_todoList.RemoveAll(todo => todo.Id == id);
        public void UpdateTodo(int id ,Todo item)
        {
           RemoveTodo(id);
              List_todoList.Add(new Todo
            {
                Id = id,
                Title = item.Title,
                StartDate = item.StartDate,
                EndDate = item.EndDate
            });
        }
        public List<Todo> getTodoActives(){
            return List_todoList.Where(todo => !todo.EndDate.HasValue).ToList();
        }
    }
}
