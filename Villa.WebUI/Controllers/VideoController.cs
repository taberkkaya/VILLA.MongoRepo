using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
