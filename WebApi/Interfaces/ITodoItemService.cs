using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemDto>> GetAllAsync();

        Task<ToDoItemDto> GetByIdAsync(int id);

        Task<ToDoItemDto> AddAsync(AddToDoItemDto addTodoItemDto);

        Task<bool> UpdateByIdAsync(int id, UpdateToDoItemDto updateToDoItemDto);

        Task UpdateRangeToDoItemsAsync(UpdateRangeToDoItemsDto updateRangeToDoItemsDto);

        Task<bool> DeleteByIdAsync(int id);
    }
}
