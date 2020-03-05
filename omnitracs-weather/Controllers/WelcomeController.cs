using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using omnitracs_weather.Services; 

namespace omnitracs_weather.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Weather() {
            return PartialView("Weather");
        }
    }
}