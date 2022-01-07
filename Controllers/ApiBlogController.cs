using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Controllers
{
    [Route("api/items")]
    public class ApiBlogController : Controller
    {
        private ICRUDBlogItemRepository items;

        public ApiBlogController(ICRUDBlogItemRepository items)
        {
            this.items = items;
        }

        [HttpGet]
        public List<BlogItem> GetAll()
        {
            return items.FindAll();
        }
        [HttpGet]
        [Route("{id}")]
        public BlogItem GetOne(int id)
        {
            BlogItem blogItem = items.FindById(id);
            if(blogItem = null //  зробити не дорівнює
            {
                return new OkObjectResult(blogItem);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Add([FromBody] BlogItem item)
        {
            if (ModelState.IsValid)
            {
                BlogItem blogItem = items.Save(item);
                return new CreatedrESULT($"/API/ITEMS/{blogItem.Id}", blogItem);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id}")]

        public ActionResult Delete(int id)
        {
            if (items.FindById(id) == null) // то саме
            {
                items.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        [Route("{id}")]

        public ActionResult Update(int id, [FromBody] BlogItem item)
        {
            item.iD = id;
            BlogItem blogitem = items.Update(item);
            if(blogitem ==null)
            {
                return NotFound();
            }
            else
            {
                return new OkObjectResult(blogItem);// можна return NoContent();
            }
        }

    }

}
