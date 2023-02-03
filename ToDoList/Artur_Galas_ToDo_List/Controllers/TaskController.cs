using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using ToDo_List_Infrastructure.Commands.Task;
using ToDo_List_Infrastructure.DTO;
using ToDo_List_Infrastructure.Services;

namespace Artur_Galas_ToDo_List.Controllers
{

    [Authorize]
    public class TaskController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        
        public TaskController(IUserService userservice,ITaskService taskService,IMapper mapper)
        {
            _taskService = taskService;
            _userService = userservice;
            _mapper = mapper;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index() 
        {
            var guid = User.Identity.Name;
            if (guid != null)
            {
                var user = await _userService.GetAsync(Guid.Parse(guid));
                List<TaskDTO> tasks = new List<TaskDTO>();
                return View(user);
            }else
                return RedirectToAction("UnAuthorized","Home");
        }
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var guid = User.Identity.Name;
            if (guid != null)
            {
                var user = await _userService.GetAsync(Guid.Parse(guid));
                var @task =_mapper.Map<TaskDetailsDTO>(user.tasks.FirstOrDefault(t=>t.id == id));
                if (@task != null)
                    return View(task);
            }
            return RedirectToAction("Index","Task");
        }
        [HttpGet("Done")]
        public async Task<IActionResult> Done(Guid id)
        {
            await _taskService.DoneTaskAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Add command)
        {
            if (ModelState.IsValid && command.EndDate>DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return RedirectToAction("Index");
            }
            //var guid = Guid.Parse(User.Identity.Name);
            //await _userService.AddTaskAsync(guid, command.Title, command.Description, command.EndDate);
            ViewBag.Error = "Data zakończenia nie może być mniejsza niż dzisiejsza.";
            return View(command);
        }
        
    }
}
