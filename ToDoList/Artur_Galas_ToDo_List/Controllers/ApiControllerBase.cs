using Microsoft.AspNetCore.Mvc;

namespace Artur_Galas_ToDo_List.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
    }
}
