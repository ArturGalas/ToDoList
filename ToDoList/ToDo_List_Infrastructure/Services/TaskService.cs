using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;

namespace ToDo_List_Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepository _tasksRepository;
        public TaskService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task DeleteTaskAsync(Guid id)
        {
            await _tasksRepository.UpdateState(id, TaskState.Remove);
            await Task.CompletedTask;
        }

        public async Task DoneTaskAsync(Guid id)
        {
            await _tasksRepository.UpdateState(id, TaskState.Done);
            await Task.CompletedTask;
        }
        public async Task ClosedTaskAsync (Guid id)
        {
            await _tasksRepository.UpdateState(id, TaskState.Closed);
            await Task.CompletedTask;
        }
    }
}
