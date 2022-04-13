using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            var result = await _toDoItemRepository.GetAllAsync();

            return result;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            var result = await _toDoItemRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<ToDoItem> AddAsync(AddToDoItemDto addTodoItemDto)
        {
            var entity = await _toDoItemRepository.AddAsync(addTodoItemDto);

            return entity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var result = await _toDoItemRepository.DeleteByIdAsync(id);

            return result;
        }

        public async Task UpdateRangeToDoItemsAsync(UpdateRangeToDoItemsDto updateRangeToDoItemsDto)
        {
            await _toDoItemRepository.UpdateRangeToDoItemsAsync(updateRangeToDoItemsDto);
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateToDoItemDto updateToDoItemDto)
        {
            var result = await _toDoItemRepository.UpdateByIdAsync(id, updateToDoItemDto);

            return result;
        }
    }
}
