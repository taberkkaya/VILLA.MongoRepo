using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class QuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
