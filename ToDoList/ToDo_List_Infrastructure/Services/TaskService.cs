using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;
        public TaskService(ITasksRepository tasksRepository,IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }
        public async Task<TaskDetailsDTO> GetByIdAsync(Guid id)
            => await Task.FromResult(_mapper.Map<TaskDetailsDTO>(_tasksRepository.GetAsync(id).Result));
        public async Task<IEnumerable<Tasks>> GetTasks(Guid userId)
            =>await Task.FromResult( await _tasksRepository.GetAllAsyncByUser(userId));
        public async Task DeleteTaskAsync(Guid id)
        {
            var @task = await _tasksRepository.GetAsync(id);
            task.State = TaskState.Remove;
            await _tasksRepository.UpdateTask(id, task);
            await Task.CompletedTask;
            task.SetUpdateDate(DateTime.Now);
        }

        public async Task DoneTaskAsync(Guid id)
        {
            var @task = await _tasksRepository.GetAsync(id);
            task.State = TaskState.Done;
            await _tasksRepository.UpdateTask(id, task);
            await Task.CompletedTask;
            task.SetUpdateDate(DateTime.Now);
        }
        public async Task ClosedTaskAsync(Guid id)
        {
            var @task = await _tasksRepository.GetAsync(id);
            task.State = TaskState.Closed;
            await _tasksRepository.UpdateTask(id, task);
            await Task.CompletedTask;
            task.SetUpdateDate(DateTime.Now);
        }
        public async Task UpdateTaskAsync(Guid id,string Title,string Description,DateTime EndDate)
        {
            var @task = await _tasksRepository.GetAsync(id);
            task.SetTitle(Title);
            task.SetDescription(Description);
            task.SetEndDate(task.EndDate);
            task.SetUpdateDate(DateTime.Now);
            await _tasksRepository.UpdateTask(id, task);
            await Task.CompletedTask;
        }
    }
}
