using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IToDoItemService
    {
        Task<List<ToDoItem>> GetAllAsync();

        Task<ToDoItem> GetByIdAsync(int id);

        Task<ToDoItem> AddAsync(AddToDoItemDto addTodoItemDto);

        Task<bool> UpdateByIdAsync(int id, UpdateToDoItemDto updateToDoItemDto);

        Task UpdateRangeToDoItemsAsync(UpdateRangeToDoItemsDto updateRangeToDoItemsDto);

        Task<bool> DeleteByIdAsync(int id);
    }
}
