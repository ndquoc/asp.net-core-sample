using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCms.Models;
using TinyCms.DAL;

namespace TinyCms.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        ApplicationDataContext _dbContext;
        public HomeController(ApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

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
        public IActionResult SubmitContact(ContactModel model)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Contacts.Add(new DAL.Entities.Contact()
                {
                    Address = model.Address,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Message = model.Message,
                    Phone = model.Phone
                });

                _dbContext.SaveChanges();
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