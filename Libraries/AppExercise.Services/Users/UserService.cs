using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppExercise.Core;
using AppExercise.Core.Models;

namespace AppExercise.Services.Todo
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<User> _todoUserRepository;

        public TodoService(IRepository<User> todoUserRepository)
        {
            _todoUserRepository = todoUserRepository;
        }

        public TodoService()
        {
        }


        //Fake Logic
        private static List<User> ListUser = new List<User>()
        {
            new User()
            {
                Username="user name 1",
                Id = 1,
                Password = "111111"
            },
            new User()
            {
                Username="user name 2",
                Id = 2,
                Password = "111111"
            }
        };



      

        public async Task<IList<User>> GetUserListsAsync()
        {
            await Task.Delay(100);
            var listData = ListUser.Select((arg) => arg).ToList();
            return listData;

        }

        public async Task CreateListAsync(User user)
        {
            await Task.Run(() => _todoUserRepository.Add(user));
        }

        public async Task AddUserToListAsync(User item)
        {
            await Task.Delay(100);
            ListUser.Add(item);
        }

        public async Task RemoveUserFromListAsync(User item)
        {
            ListUser = ListUser.Where((User arg) => arg.Id != item.Id).ToList();
            await Task.Delay(100);
        }
    }
}
