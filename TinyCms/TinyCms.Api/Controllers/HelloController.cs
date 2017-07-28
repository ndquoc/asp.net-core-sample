using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCms.Api.Models;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace TinyCms.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class HelloController : Controller
    {
        private static List<HelloModel> _listItems = new List<HelloModel>(new HelloModel[] {
            new HelloModel(){ Title="Item 1", Id = Guid.NewGuid().ToString()},
            new HelloModel() { Title = "Item 2", Id = Guid.NewGuid().ToString()}
        });

        [HttpGet]
        public IEnumerable<HelloModel> Get()
        {
            return _listItems;
        }

        [HttpGet("{id}")]
        public HelloModel Get(string id)
        {
            return _listItems.FirstOrDefault(p => p.Id == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]HelloModel value)
        {
            value.Id = Guid.NewGuid().ToString();
            _listItems.Add(value);
            return new ObjectResult(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]HelloModel value)
        {
            var item = _listItems.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                item.Title = value.Title;

                return new ObjectResult(item);
            }
            else
            {
                return StatusCode(404);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _listItems.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _listItems.Remove(item);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404);
            }
        }
    }
}
