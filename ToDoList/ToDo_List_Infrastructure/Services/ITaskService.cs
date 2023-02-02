using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Infrastructure.Services
{
    public interface ITaskService
    {
        public Task DeleteTaskAsync(Guid id);
        public Task DoneTaskAsync(Guid id);
        public Task ClosedTaskAsync(Guid id);
    }
}
