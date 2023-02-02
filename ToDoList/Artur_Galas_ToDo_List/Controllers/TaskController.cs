using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDo_List_Infrastructure.Commands.Task;
using ToDo_List_Infrastructure.DTO;
using ToDo_List_Infrastructure.Services;

namespace Artur_Galas_ToDo_List.Controllers
{
    [Route("[controller]")]
    //[Authorize]
    public class TaskController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        private readonly UserDTO _user;
        
        public TaskController(IUserService userservice,ITaskService taskService)
        {
            _taskService = taskService;
            _userService = userservice;
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
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            TaskDetailsDTO ts = new TaskDetailsDTO() {
                Title = id,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                EndDate = DateTime.UtcNow,
                state = ToDo_List_Core.Models.TaskState.Active,
            };
            return View(ts);
        }
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Add command)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //var guid = Guid.Parse(User.Identity.Name);
            //await _userService.AddTaskAsync(guid, command.Title, command.Description, command.EndDate);
            return View(command);
        }
        [HttpGet]
        public async Task<IActionResult> Done(Guid id)
        {
            _taskService.DoneTaskAsync(id);
            return RedirectToAction("Index");
        }
    }
}
