using Microsoft.AspNetCore.Mvc;

namespace Artur_Galas_ToDo_List.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult UnAuthorized()
        {
            return View();
        }
    }
}
