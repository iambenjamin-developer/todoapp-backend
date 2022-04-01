using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class TodoItemService : ITodoItemService
    {
        public async Task<List<ToDoItem>> GetAllAsync()
        {
            var todoItems = GetMockList();

            return todoItems;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            var todoItems = GetMockList();

            return todoItems.FirstOrDefault(x => x.Id == id);
        }

        public async Task<ToDoItem> AddAsync(AddTodoItemDto addTodoItemDto)
        {
            var todoItems = GetMockList();

            var lastId = todoItems.Max(x => x.Id);

            var newToDoItem = new ToDoItem
            {
                Id = lastId + 1,
                Name = addTodoItemDto.Name,
                IsCompleted = false
            };

            todoItems.Add(newToDoItem);

            return newToDoItem;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var todoItems = GetMockList();
            int itemsBefore = todoItems.Count;
            var itemDeleted = todoItems.FirstOrDefault(x => x.Id == id);

            if (itemDeleted == null)
            {
                return false;
            }

            todoItems = todoItems.Where(x => x.Id != id).ToList();

            int itemsAfter = todoItems.Count;

            if ((itemsBefore - 1) == itemsAfter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static List<ToDoItem> GetMockList()
        {
            var list = new List<ToDoItem> {
            new ToDoItem{
                Id = 1,
                Name ="Name 1",
                IsCompleted = true
            },
                        new ToDoItem{
                Id = 2,
                Name ="Name 2",
                IsCompleted = true
            },
            new ToDoItem{
                Id = 3,
                Name ="Name 3",
                IsCompleted = false
            },
            new ToDoItem{
                Id = 4,
                Name ="Name 4",
                IsCompleted = true
            },
            };

            return list;
        }
    }
}
