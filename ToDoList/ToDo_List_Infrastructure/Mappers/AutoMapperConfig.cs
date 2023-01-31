using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(p=>p.UserId, m=>m.MapFrom(p=>p.id))
                .ForMember(p=>p.CreateAt,m=>m.MapFrom(p=>p.CreatedAt));
                cfg.CreateMap<User, AccountDTO>()
                .ForMember(p => p.id, m => m.MapFrom(p => p.id))
                .ForMember(p => p.role, m => m.MapFrom(p => p.role));
                cfg.CreateMap<Tasks, TaskDetailsDTO>();
                cfg.CreateMap<Task, TaskDTO>();
            }).CreateMapper(); 
    }
}
