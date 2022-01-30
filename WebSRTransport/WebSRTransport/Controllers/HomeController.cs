using Microsoft.AspNetCore.Mvc;

namespace WebSRTransport.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            Response.Redirect("swagger/index.html");
        }
    }
}
