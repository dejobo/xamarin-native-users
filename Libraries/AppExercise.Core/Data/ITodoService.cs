using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppExercise.Core.Models;

namespace AppExercise.Services.Todo
{
    public interface ITodoService
    {
        Task<IList<User>> GetUserListsAsync();
        Task CreateListAsync(User todoList);
        Task AddUserToListAsync(User item);
        Task RemoveUserFromListAsync(User item);
    }
}
