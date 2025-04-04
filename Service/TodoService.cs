namespace Todo
{
    public class TodoService
    {
        private List<TodoDto> List_todoList = new List<TodoDto>()
        {
            new TodoDto ( 1 ,  "Csharp", DateTime.Now, null ),
            new TodoDto ( 2 ,  "Lua", DateTime.Now, null ),
            new TodoDto ( 3 ,  "Java", DateTime.Now, null )
        };


        public List<TodoDto> getAll()
        {
            return List_todoList;
        }
        public TodoDto getTodoById(int id)
        {
            return List_todoList.Find(todo => todo.Id == id) ?? throw new InvalidOperationException("Todo not found");
        }
        public TodoDto AddTodo(string titre)
        {
            int id = List_todoList.Count == 0 ? 1 : List_todoList.Max(todo => todo.Id) + 1;
            TodoDto todo = new TodoDto
            (                
                id,
                 titre,
                DateTime.Now,
                 null

            );
            List_todoList.Add(todo);
            return todo;
        }
        public bool RemoveTodo(int id) {
                var todo = getTodoById(id);
                if (todo != null) {
                    List_todoList.Remove(todo);
                    return true;
                }
                return false;
        }      
         public void UpdateTodo(int id ,TodoDto item)
        {
           RemoveTodo(id);
              List_todoList.Add(new TodoDto
            (
                id,
                item.Title,
                item.StartDate,
                 item.EndDate
              ));
        }
        public List<TodoDto> getTodoActives(){
            return List_todoList.Where(todo => !todo.EndDate.HasValue).ToList();
        }
    }
}
