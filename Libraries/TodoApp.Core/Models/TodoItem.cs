using System;
using System.Data.Common;
using System.Windows.Input;
using MvvmCross.Commands;

namespace TodoApp.Core.Models
{
    public class TodoItem : BaseModel
    {
        public TodoItem() { }

        public int TodoListId { get; set; } = -1;
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string CompletedString
        {
            get
            {
                if (Completed == true)
                {
                    return "Completed";
                }
                return "In Progress";
            }
        }
       
    }
}
