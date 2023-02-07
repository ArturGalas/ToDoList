using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;
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
                var tasks = await _taskService.GetTasks(Guid.Parse(guid));
                user.tasks = _mapper.Map<IEnumerable<TaskDTO>>(tasks);
                return View(user);
            }else
                return RedirectToAction("UnAuthorized","Home");
        }
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }
        [HttpGet("Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            var guid = User.Identity.Name;
            if (guid != null)
            {
                var @task = _mapper.Map<TaskDetailsDTO>(await _taskService.GetByIdAsync(id));
                if (@task != null)
                    return View(task);
            }
            return RedirectToAction("Index", "Task");
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
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var @task = _mapper.Map<Edit>(await _taskService.GetByIdAsync(id));
            if (@task != null)
                return View(task);
            else
                return RedirectToAction("Index", "Task");
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Edit command)
        {
            await _taskService.UpdateTaskAsync(command.Id, command.Title, command.Description, command.EndDate);
            return RedirectToAction("Details", "Task", new { id = command.Id });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Add command)
        {
            if (ModelState.IsValid && command.EndDate>DateTime.UtcNow)
            {
                var guid = Guid.Parse(User.Identity.Name);
                await _userService.AddTaskAsync(guid, command.Title, command.Description, command.EndDate);
                return RedirectToAction("Index");
            }           
            ViewBag.Error = "Data zakończenia nie może być mniejsza niż dzisiejsza.";
            return View(command);
        }
        
    }
}
