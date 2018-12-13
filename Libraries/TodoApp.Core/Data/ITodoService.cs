using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Models;

namespace TodoApp.Services.Todo
{
    public interface ITodoService
    {
        Task<IList<TodoList>> GetTodoLists();
        Task<TodoList> GetTodoList(int todoListId);
        Task CreateList(TodoList todoList);
        Task EditList(TodoList todoList);
        Task DeleteList(int todoListId);
        Task MarkListAsCompleted(int todoListId);
        Task MakeListActive(int todoListId);

        Task<IList<TodoItem>> GetItemsFromList(int todoListId);
        Task<TodoItem> GetItem(int todoItemId);
        Task AddItemToList(TodoItem item);
        Task UpdateItemOnList(TodoItem item);
        Task RemoveItemFromList(TodoItem item);
        Task MarkItemAsCompleted(int todoItemId);

        Task<TodoList> GetFakeTodoListByIdAsync(int todoListId);
        Task<List<TodoList>> GetFakeTodoListAsync();
        Task UpdateTodoListAsync(TodoList item);
        Task AddTodoListAsync(TodoList item);
        Task RemoveTodoListAsync(TodoList item);
        Task UpdateTodoItemAsync(TodoItem item);
        Task AddTodoItemAsync(TodoItem item);
        Task RemoveTodoItemAsync(TodoItem item);
    }
}
