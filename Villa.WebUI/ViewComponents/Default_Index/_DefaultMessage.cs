using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultMessage : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
