using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Core.Repositories;
using ToDo_List_Infrastructure.DataBaseContext;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Repositories
{
    public class TaskRepository : ITasksRepository
    {
        private readonly ContextDb _DbContext;
        private readonly IMapper _mapper;
        public TaskRepository(ContextDb dbContext,IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync()
        => await Task.FromResult(_DbContext.tasks);
    }
}
