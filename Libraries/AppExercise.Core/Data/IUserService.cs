using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppExercise.Core.Models;

namespace AppExercise.Services.Users
{
    public interface ITodoService
    {
        Task<IList<Core.Models.User>> GetUserListsAsync();
        Task CreateListAsync(Core.Models.User todoList);
        Task AddUserToListAsync(Core.Models.User item);
        Task RemoveUserFromListAsync(Core.Models.User item);
    }
}
