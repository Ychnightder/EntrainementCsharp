using System.Reflection;
using System.Text.Json;

namespace Todo
{
    public record class TodoDto(int Id , string Title, DateTime StartDate , DateTime? EndDate = null);
        
}
