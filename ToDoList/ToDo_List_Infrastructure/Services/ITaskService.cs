using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Services
{
    public interface ITaskService
    {
        public Task<TaskDetailsDTO> GetByIdAsync(Guid id);
        public Task<IEnumerable<Tasks>> GetTasks(Guid userId);
        public Task DeleteTaskAsync(Guid id);
        public Task DoneTaskAsync(Guid id);
        public Task ClosedTaskAsync(Guid id);
        public Task UpdateTaskAsync(Guid id, string Title, string Description, DateTime EndDate);
    }
}
