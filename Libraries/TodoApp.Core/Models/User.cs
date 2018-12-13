using System;
using System.Data.Common;
using System.Windows.Input;
using MvvmCross.Commands;

namespace TodoApp.Core.Models
{
    public class User : BaseModel
    {
        public User() { }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
