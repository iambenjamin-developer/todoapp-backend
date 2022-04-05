using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Infrastructure;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            var result = await _context.ToDoItems.ToListAsync();

            return result;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            var result = await _context.ToDoItems
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<ToDoItem> AddAsync(AddTodoItemDto addTodoItemDto)
        {
            var entity = new ToDoItem
            {
                Name = addTodoItemDto.Name,
                IsCompleted = false
            };

            _context.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {

            var entity = await _context.ToDoItems
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);


            var result = await _context.SaveChangesAsync();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task UpdateAsync(UpdateToDoItemsDto updateToDoItemsDto)
        {
            foreach (var ToDoItemId in updateToDoItemsDto.ToDoItemIds)
            {
                var entity = await _context.ToDoItems
                          .Where(x => x.Id == ToDoItemId)
                          .FirstOrDefaultAsync();

                entity.IsCompleted = updateToDoItemsDto.CheckToDoItemsLikeCompleted;
            }

            await _context.SaveChangesAsync();
        }
    }
}
