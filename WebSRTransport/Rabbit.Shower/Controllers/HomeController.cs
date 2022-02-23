using Microsoft.AspNetCore.Mvc;

namespace Rabbit.Shower.Controllers
{
    public class HomeController : AuthorizedController
    {
        public IActionResult Index()
        {
            SetAuthViewData();
            return View();
        }
    }
}
