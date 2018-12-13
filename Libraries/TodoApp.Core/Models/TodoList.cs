using System;
using System.Collections.Generic;

namespace TodoApp.Core.Models
{
    public class TodoList: BaseModel
    {
        public TodoList()
        {
            TodoItems = new List<TodoItem>();
        }
        public string Name { get; set; }
        public bool Active { get; set; }

        public List<TodoItem> TodoItems { get; set; }

        public static implicit operator TodoList(List<TodoList> v)
        {
            throw new NotImplementedException();
        }
    }
}
