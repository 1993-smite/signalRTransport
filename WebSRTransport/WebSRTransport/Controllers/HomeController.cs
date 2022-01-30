using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
