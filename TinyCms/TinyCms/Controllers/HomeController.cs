using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCms.Models;

namespace TinyCms.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }

        [HttpGet("About")]
        public IActionResult AboutUs()
        {
            ViewBag.Title = "About Us";
            return View("About");
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Constact";
            return View();
        }

        [HttpPost("Contact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitContact(ContactModel model)
        {
            if(ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                return View("Contact", new ContactModel());
            }
            else
            {
                ViewBag.IsSuccess = false;
                return View("Contact", model);
            }
        }
    }
}