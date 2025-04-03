using System.Reflection;
using System.Text.Json;

namespace Todo
{
    public class Todo
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        
    }
}
