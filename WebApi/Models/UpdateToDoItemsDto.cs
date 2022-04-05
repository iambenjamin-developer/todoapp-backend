using System.Collections.Generic;

namespace WebApi.Models
{
    public class UpdateToDoItemsDto
    {
        public List<int> ToDoItemIds { get; set; }
        public bool CheckToDoItemsLikeCompleted { get; set; }
    }
}
