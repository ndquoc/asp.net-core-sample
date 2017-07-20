using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TinyCms.DAL.Repositories;
using TinyCms.Controllers;
using TinyCms.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
namespace TinyCms.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void Home_SubmitContact_WhenModelStateIsInvalid()
        {
            var mockRepo = new Mock<IContactRepository>();
            var controller = new HomeController(mockRepo.Object);

            var model = new ContactModel();

            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);


            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            var result = (ViewResult)controller.SubmitContact(model);
            
            Assert.Equal(false, result.ViewData.ModelState.IsValid);
        }
    }
}
