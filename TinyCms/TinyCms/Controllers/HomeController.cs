using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCms.Models;
using TinyCms.DAL.Repositories;

namespace TinyCms.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        IContactRepository _contactRepo;
        public HomeController(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
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
                _contactRepo.Add(new DAL.Entities.Contact()
                {
                    Address = model.Address,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Message = model.Message,
                    Phone = model.Phone
                });

                _contactRepo.Save();
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