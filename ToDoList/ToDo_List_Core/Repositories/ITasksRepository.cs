using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Core.Repositories
{
    public interface ITasksRepository
    {
        public Task<IEnumerable<Tasks>> GetAllAsync();
        public Task<Tasks> GetAsync(Guid id);
        public Task UpdateTask(Guid id, Tasks task);
    }
}
