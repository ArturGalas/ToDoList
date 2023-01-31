using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.Commands;
using ToDo_List_Infrastructure.Commands.User;
using ToDo_List_Infrastructure.Services;

namespace Artur_Galas_ToDo_List.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("/User")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var @user = _userService.GetAccountAsync(UserId).Result;
                if (UserId != Guid.Empty)
                {
                    return View(user);
                }
            }
            catch
            {
                return View(null);
            }
            return View(null);
        }
        [HttpPost("/User/Register")]
        public async Task<IActionResult> Register(CreateUser command)
        {
            try
            {
                var id = await Task.FromResult(_userService.CreateAsync(command.Email, command.Password, command.Name, command.role = Role.Admin).Result);
                return RedirectToAction(actionName: "Login");
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("already exist"))
                    ViewBag.Error = "Taki użytkownik już istnieje";
                return View();
            }
            
        }
        [HttpGet("/User/Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpGet("/User/Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost("/User/Login")]
        public async Task<ActionResult> Login(Login command)
        {
            try
            {
                var token = await _userService.LoginAsync(command.username, command.password);
                Response.Cookies.Append("Bearer", token.Token, new CookieOptions { HttpOnly = true });
                return RedirectToAction(actionName: "Index");
            }catch(Exception)
            {
                ViewBag.Error = "Błędne dane logowania";
                return View();
            }
        }
        [HttpGet("User/LogOut")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Bearer");
            return View();
        }
    }
}
