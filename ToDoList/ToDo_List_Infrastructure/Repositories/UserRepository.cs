using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;
using ToDo_List_Infrastructure.DataBaseContext;

namespace ToDo_List_Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _DbContext;
        public UserRepository(ContextDb dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task CreateAsync(User user)
        {
            await Task.FromResult(_DbContext.Users.AddAsync(user));
            _DbContext.SaveChanges();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = GetAsync(id).Result;
            user.RemoveUser();
            _DbContext.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        => await Task.FromResult(_DbContext.Users.Where(us => us.state == UserState.Active));
        public async Task<User> GetAsync(Guid id)
        => await Task.FromResult(_DbContext.Users.SingleOrDefault(us => us.id == id));

        public async Task<User> GetAsync(string email)
        => await Task.FromResult(_DbContext.Users.SingleOrDefault(us => us.email == email));

        public async Task UpdateAsync()
        {
            _DbContext.SaveChanges();
        }
        public async Task AddTaskAsync(User user,Tasks newTask)
        {
            user.AddTask(newTask);
            _DbContext.SaveChanges();
        }

    }
}
