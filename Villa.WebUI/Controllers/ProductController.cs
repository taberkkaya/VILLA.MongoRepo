using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
