using Microsoft.AspNetCore.Mvc;

namespace Rabbit.Shower.Controllers
{
    public class AuthorizedController : Controller
    {
        public string Login => User?.Identity.Name ?? "";
        public bool IsAuthenticated => User?.Identity.IsAuthenticated ?? false;

        public void SetAuthViewData()
        {
            ViewData[nameof(Login)] = Login;
            ViewData[nameof(IsAuthenticated)] = IsAuthenticated;
        }
    }
}
