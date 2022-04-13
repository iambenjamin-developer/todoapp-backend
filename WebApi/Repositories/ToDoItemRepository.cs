using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Infrastructure;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {

        private readonly ApplicationDbContext _context;

        public ToDoItemRepository(ApplicationDbContext context)
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

        public async Task<ToDoItem> AddAsync(AddToDoItemDto addTodoItemDto)
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

        public async Task UpdateRangeToDoItemsAsync(UpdateRangeToDoItemsDto updateRangeToDoItemsDto)
        {
            foreach (var toDoItemId in updateRangeToDoItemsDto.ToDoItemIds)
            {
                var entity = await _context.ToDoItems
                          .Where(x => x.Id == toDoItemId)
                          .FirstOrDefaultAsync();

                entity.IsCompleted = updateRangeToDoItemsDto.MarkAsCompleted;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateByIdAsync(int id, UpdateToDoItemDto updateToDoItemDto)
        {
            var entity = await _context.ToDoItems
                      .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            entity.IsCompleted = updateToDoItemDto.MarkAsCompleted;

            await _context.SaveChangesAsync();

            return true;

        }

    }
}