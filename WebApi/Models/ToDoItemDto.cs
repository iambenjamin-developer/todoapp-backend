using WebApi.Entities;
using WebApi.Mappings;

namespace WebApi.Models
{
    public class ToDoItemDto : IMapFrom<ToDoItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
