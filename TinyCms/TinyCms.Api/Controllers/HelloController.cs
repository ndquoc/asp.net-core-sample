using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCms.Api.Models;

namespace TinyCms.Api.Controllers
{
    [Route("api/[controller]")]
    public class HelloController: Controller
    {
        private static List<HelloModel> _listItems = new List<HelloModel>(new HelloModel[] {
            new HelloModel(){ Title="Item 1", Id = Guid.NewGuid()},
            new HelloModel() { Title = "Item 2", Id = Guid.NewGuid()}
        });

        [HttpGet]
        public IEnumerable<HelloModel> Get()
        {
            return _listItems;
        }
    }
}
