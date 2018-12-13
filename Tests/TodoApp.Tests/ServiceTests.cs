using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Services.Todo;
using TodoApp.Data.InMemory;
using TodoApp.Core.Models;

namespace TodoApp.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private readonly ITodoService service;
        public ServiceTests()
        {
            service = new TodoService(
                new InMemoryRepository<TodoList>(), new InMemoryRepository<TodoItem>());
        }
        [TestMethod]
        public void create_new_todo_list()
        {            
            service.CreateList(new TodoList { Id = 1, Name = "1st List" });
            service.CreateList(new TodoList { Id = 1, Name = "2nd List" });
            var lists = service.GetTodoLists();
            Assert.IsTrue(lists.Result.Count > 1);
        }

        [TestMethod]
        public void add_items_to_list()
        {
            service.CreateList(new TodoList { Id = 1, Name = "1st List" });
            service.CreateList(new TodoList { Id = 2, Name = "2nd List" });

            service.AddItemToList(new TodoItem { Id = 1, Description = "1st Item", TodoListId = 1 });
            service.AddItemToList(new TodoItem { Id = 2, Description = "2nd Item", TodoListId = 1 });
            service.AddItemToList(new TodoItem { Id = 3, Description = "3rd Item", TodoListId = 1 });
            service.AddItemToList(new TodoItem { Id = 4, Description = "3rd Item", TodoListId = 2 });

            var lists1 = service.GetItemsFromList(1).Result;
            var lists2 = service.GetItemsFromList(2).Result;
            Assert.IsTrue(lists1.Count == 3);
            Assert.IsTrue(lists2.Count == 1);
        }
    }
}
