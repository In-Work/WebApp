using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
