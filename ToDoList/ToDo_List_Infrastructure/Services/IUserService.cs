using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Services
{
    public interface IUserService
    {
        public Task<UserDTO> GetAsync(Guid id);
        public Task<UserDTO> GetAsync(string email);
        public Task<IEnumerable<UserDTO>> GetAllAsync();
        public Task<TokenDTO> CreateAsync(string email,string password,string name,Role role);
        public Task<Guid> AddTaskAsync(Guid id, string title, string description, DateTime enddate);
        public Task DeleteAsync(Guid id);
        public Task UpdateAsync(Guid id,string? name, string? email,string? password);
        public Task<TokenDTO> LoginAsync(string username,string password);
        public Task<AccountDTO> GetAccountAsync(Guid id);
    }
}
