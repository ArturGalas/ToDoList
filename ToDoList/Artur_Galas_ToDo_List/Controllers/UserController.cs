using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.Commands;
using ToDo_List_Infrastructure.Commands.User;
using ToDo_List_Infrastructure.DTO;
using ToDo_List_Infrastructure.Services;

namespace Artur_Galas_ToDo_List.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [Route("/")]
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var @user = _userService.GetAccountAsync(UserId).Result;
                return View(user);
            }
            catch
            {
                return View(null);
            }
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [Authorize]
        [HttpGet("Details")]
        public async Task<IActionResult> Details()
        {
            var guid =Guid.Parse(User.Identity.Name);
            var @user = _mapper.Map<Details>( await _userService.GetUserAsync(guid));
            return View(user);
        }
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit()
        {
            var guid =Guid.Parse(User.Identity.Name);
            var @user = _mapper.Map<Details>(await _userService.GetAccountAsync(guid));
            return View(user);
        }
        [HttpGet("LogOut")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Bearer");
            return View();
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> Login(Login command)
        {
            try
            {
                var token = await _userService.LoginAsync(command.username, command.password);
                Response.Cookies.Append("Bearer", token.Token, new CookieOptions { HttpOnly = true });
                return RedirectToAction(actionName: "Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Błędne dane logowania";
                return View();
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUser command)
        {
            try
            {
                var id = await Task.FromResult(_userService.CreateAsync(command.Email, command.Password, command.Name, Role.User).Result);
                var token = await _userService.LoginAsync(command.Email, command.Password);
                Response.Cookies.Append("Bearer", token.Token, new CookieOptions { HttpOnly = true });
                return RedirectToAction(actionName: "Index");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("already exist"))
                    ViewBag.Error = "Taki użytkownik już istnieje";
                ViewBag.Error = ex.Message;
                return View();
            }

        }
        [Authorize]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Details command)
        {
            var guid =Guid.Parse(User.Identity.Name);
            var @user = await _userService.GetAccountAsync(guid);
            await _userService.UpdateAsync(guid, command.name, command.email,command.password);
            return RedirectToAction(actionName: "Details");
        }
    }
}
