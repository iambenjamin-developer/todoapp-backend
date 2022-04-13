using AutoMapper;
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
        private readonly IMapper _mapper;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, IMapper mapper)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
        }

        public async Task<List<ToDoItemDto>> GetAllAsync()
        {
            var entities = await _toDoItemRepository.GetAllAsync();

            var dtos = _mapper.Map<List<ToDoItem>, List<ToDoItemDto>>(entities);

            return dtos;
        }

        public async Task<ToDoItemDto> GetByIdAsync(int id)
        {
            var entity = await _toDoItemRepository.GetByIdAsync(id);

            var dto = _mapper.Map<ToDoItem, ToDoItemDto>(entity);

            return dto;
        }

        public async Task<ToDoItemDto> AddAsync(AddToDoItemDto addTodoItemDto)
        {
            var entity = await _toDoItemRepository.AddAsync(addTodoItemDto);

            var dto = _mapper.Map<ToDoItem, ToDoItemDto>(entity);

            return dto;
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
