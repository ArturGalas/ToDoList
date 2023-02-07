using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.Commands.Task;
using ToDo_List_Infrastructure.Commands.User;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(p => p.UserId, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.CreateAt, m => m.MapFrom(p => p.CreatedAt))
                .ForMember(p => p.CreateAt, m => m.MapFrom(p => p.CreatedAt));
                cfg.CreateMap<User, AccountDTO>()
                .ForMember(p => p.id, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.role, m => m.MapFrom(p => p.role))
                .ForMember(p => p.email, m => m.MapFrom(p => p.email))
                .ForMember(p => p.name, m => m.MapFrom(p => p.name));
                cfg.CreateMap<User, Details>()
                .ForMember(p=>p.id,m=>m.MapFrom(p=>p.Id));
                cfg.CreateMap<Tasks, TaskDetailsDTO>()
                .ForMember(p => p.EndDate, m => m.MapFrom(p => p.EndDate))
                .ForMember(p => p.Id, m => m.MapFrom(p => p.Id));
                cfg.CreateMap<Tasks, TaskDTO>();
                cfg.CreateMap<TaskDTO, TaskDetailsDTO>();
                cfg.CreateMap<TaskDetailsDTO, Edit>();
            }).CreateMapper(); 
    }
}
