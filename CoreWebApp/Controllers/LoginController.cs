using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
