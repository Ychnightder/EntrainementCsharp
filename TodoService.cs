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
        public Todo getOneTodo(int id)
        {
            return List_todoList.Find(todo => todo.Id == id);
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

        public void UpdateTodo(int id, string? nouveauTitre, DateTime? end)
        {
            var todo = List_todoList.FirstOrDefault(t => t.Id == id);

            if (todo != null)
            {
                if (nouveauTitre != null)
                {
                    todo.Title = nouveauTitre;
                }

                if (end.HasValue)
                {
                    todo.EndDate = end.Value;
                }
            }
        }
    }
}
