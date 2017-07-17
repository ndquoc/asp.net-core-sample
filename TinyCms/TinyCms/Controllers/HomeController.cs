using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TinyCms.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }

        [Route("Home/About")]
        public IActionResult AboutUs()
        {
            ViewBag.Title = "About Us";
            return View("About");
        }
    }
}