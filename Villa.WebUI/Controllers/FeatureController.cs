using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}