using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core;
using TodoApp.Core.Models;

namespace TodoApp.Services.Todo
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<TodoList> _todoListRepository;
        private readonly IRepository<TodoItem> _todoItemRepository;

        public TodoService(IRepository<TodoList> todoListRepository,
            IRepository<TodoItem> todoItemRepository)
        {
            _todoListRepository = todoListRepository;
            _todoItemRepository = todoItemRepository;
        }

        public TodoService()
        {
        }

        public async Task AddItemToList(TodoItem item)
        {            
            await Task.Run(() => _todoItemRepository.Add(item));            
        }

        public async Task CreateList(TodoList todoList)
        {
            await Task.Run(() =>  _todoListRepository.Add(todoList));
        }

        public async Task DeleteList(int todoListId)
        {
            var todoList = _todoListRepository.GetById(todoListId);
            await Task.Run(() => _todoListRepository.Delete(todoList));
        }

        public async Task EditList(TodoList todoList)
        {
            await Task.Run(() => _todoListRepository.Update(todoList));
        }

        public async Task<TodoItem> GetItem(int todoItemId)
        {
            return await Task.FromResult(_todoItemRepository.GetById(todoItemId));
        }

        public async Task<IList<TodoItem>> GetItemsFromList(int todoListId)
        {
            //var todoList = _todoListRepository.GetById(todoListId);
            //return await Task.FromResult(todoList.TodoItems);
            var items = _todoItemRepository.Collection.Where(x => x.TodoListId == todoListId);
            return await Task.FromResult(items.ToList());
        }

        public async Task<TodoList> GetTodoList(int todoListId)
        {
            var todoList = _todoListRepository.GetById(todoListId);
            return await Task.FromResult(todoList);
        }



        public async Task<IList<TodoList>> GetTodoLists()
        {
            return await Task.FromResult(_todoListRepository.Collection);
        }

        public async Task MakeListActive(int todoListId)
        {
            var todoList = await Task.FromResult(_todoListRepository.GetById(todoListId));
            todoList.Active = true;
            _todoListRepository.Update(todoList);
        }

        public async Task MarkItemAsCompleted(int todoItemId)
        {
            var item = await Task.FromResult(_todoItemRepository.GetById(todoItemId));
            item.Completed = true;
            _todoItemRepository.Update(item);
        }

        public async Task MarkListAsCompleted(int todoListId)
        {
            var todoList = await Task.FromResult(_todoListRepository.GetById(todoListId));
           // todoList.c = true;
            _todoListRepository.Update(todoList);
        }

        public async Task RemoveItemFromList(TodoItem item)
        {
            await Task.Run(() => _todoItemRepository.Delete(item));
        }

        public async Task UpdateItemOnList(TodoItem item)
        {
            await Task.Run(() => _todoItemRepository.Update(item));
        }



        //Fake Logic
        private static List<TodoItem> TodoItems = new List<TodoItem>()
        {
            new TodoItem()
            {
                Description = "Work on BE",
                Id = 1,
                Completed = false,
                TodoListId = 1,
            },
            new TodoItem()
            {
                TodoListId = 1,
                Description = "Meeting with Client",
                Id = 2,
                Completed = true,
            },
            new TodoItem()
            {
                Id = 3,
                Description = "Design a Template",
                TodoListId = 1,
                Completed = false,
            },
            new TodoItem()
            {
                Id = 4,
                Description = "Work on Server",
                TodoListId = 2,
                Completed = false,
            },
            new TodoItem()
            {
                Id = 5,
                Description = "Config the system",
                TodoListId = 1,
                Completed = false,
            },
        };

        private static List<TodoList> localListTodo = new List<TodoList>()
        {
            new TodoList()
            {
                Id = 1,
                Name = "August 2018",
                Active = true,
                TodoItems = null,
            },
            new TodoList()
            {
                Id = 2,
                Name = "July 2018",
                Active = false,
                TodoItems = null,
            },
            new TodoList()
            {
                Id = 3,
                Name = "May 2018",
                Active = false,
                TodoItems = null,
            },
        };

       

        public async Task<TodoList> GetFakeTodoListByIdAsync(int todoListId)
        {
            var todo = localListTodo.Where((TodoList arg) => arg.Id == todoListId).Single();
            if(todo != null)
            {
                todo.TodoItems = TodoItems.Where((TodoItem arg) => arg.TodoListId == todo.Id).ToList();    
            }
            await Task.Delay(100);
            return todo;
        }

        public async Task UpdateTodoListAsync(TodoList item)
        {
            bool is_active = item.Active;
            if (item.Active)
            {
                ResetActiveState();
            }

            localListTodo.Where((TodoList arg) => arg.Id == item.Id).ToList().ForEach((TodoList obj) =>
            {
                obj.Active = is_active;
                obj.Name = item.Name;
            });
            await Task.Delay(100);
        }

        public async Task AddTodoListAsync(TodoList item)
        {
            if(item.Active)
            {
                ResetActiveState();
            }
            int max = localListTodo.Max((arg) => arg.Id) + 1;
            item.Id = max;
            localListTodo.Add(item);
            await Task.Delay(100);
        }

        public async Task RemoveTodoListAsync(TodoList item)
        {
            localListTodo = localListTodo.Where((TodoList arg) => arg.Id != item.Id).ToList();
            await Task.Delay(100);
        }

        public async Task UpdateTodoItemAsync(TodoItem item)
        {
            TodoItems.Where((TodoItem arg) => arg.Id == item.Id).ToList().ForEach((TodoItem obj) =>
            {
                obj.Description = item.Description;
                obj.Completed = item.Completed;
                obj.Id = item.Id;
                obj.TodoListId = item.TodoListId;
            });
            await Task.Delay(100);
        }

        public async Task AddTodoItemAsync(TodoItem item)
        {
            int max = TodoItems.Max((arg) => arg.Id) + 1;
            item.Id = max;
            TodoItems.Add(item);
            await Task.Delay(100);
        }

        private void ResetActiveState()
        {
            localListTodo = localListTodo.Select((TodoList arg) =>
            {
                arg.Active = false;
                return arg;
            }).ToList();
        }

        public async Task RemoveTodoItemAsync(TodoItem item)
        {
            TodoItems = TodoItems.Where((TodoItem arg) => arg.Id != item.Id).ToList();
            await Task.Delay(100);
        }

        public async Task<List<TodoList>> GetFakeTodoListAsync()
        {
            await Task.Delay(100);
            localListTodo = localListTodo.Select((TodoList arg) =>
            {
                arg.TodoItems = TodoItems.Where((TodoItem item) => arg.Id == item.TodoListId).ToList();
                return arg;
            }).ToList();
            return localListTodo;
        }
    }
}
