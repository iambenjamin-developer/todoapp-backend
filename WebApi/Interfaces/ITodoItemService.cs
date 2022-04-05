using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ITodoItemService
    {
        Task<List<ToDoItem>> GetAllAsync();

        Task<ToDoItem> GetByIdAsync(int id);

        Task<ToDoItem> AddAsync(AddTodoItemDto addTodoItemDto);

        Task UpdateRangeToDoItemsAsync(UpdateRangeToDoItemsDto updateRangeToDoItemsDto);

        Task<bool> DeleteByIdAsync(int id);

    }
}
