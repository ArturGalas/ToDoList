using Microsoft.AspNetCore.Mvc;

namespace Artur_Galas_ToDo_List.Controllers
{
    public class HomeController : Controller
    {
        [Route("Unauthorized")]
        public IActionResult UnAuthorized()
        {
            return View();
        }
    }
}
