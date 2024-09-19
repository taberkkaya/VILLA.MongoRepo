using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
