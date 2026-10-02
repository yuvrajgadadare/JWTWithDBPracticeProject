using Microsoft.AspNetCore.Mvc;

namespace JWTWithCoreApis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
