using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DAL;
using WebAPI.DAL.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CategoryList(Category category)
        {
            var values = context.Categories.Add(category);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var values = context.Categories.Find(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category category)
        {
            var values = context.Categories.Find(category.ID);
            values.Name = category.Name;
            values.Description = category.Description;
            values.Status = category.Status;
            context.SaveChanges();
            return Ok();
        }
    }
}
