using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;

namespace ToDo_List_Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static async Task<User> GetOrFail(this IUserRepository repository,Guid id)
        {
            var @user = await repository.GetAsync(id);
            if (@user == null)
            {
                throw new Exception("User doesn't exist");
            }
            return @user;
        }
        public static async Task<User> GetOrFail(this IUserRepository repository, string name)
        {
            var @user = await repository.GetAsync(name);
            if (@user == null)
            {
                throw new Exception("User doesn't exist");
            }
            return @user;
        }
    }
}
