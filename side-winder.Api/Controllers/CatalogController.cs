using Microsoft.AspNetCore.Mvc;
using side.winder.Domain.Catalog;
using side.winder.Data;
using Microsoft.EntityFrameworkCore;

namespace side.winder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetItems()
        {

            // var items = new List<Item>()
            // {
            //     new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
            //     new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            // };
            
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.ID = id;
            
            return Ok(item);
        }

        [HttpPost] //updated via step 5, pg 25
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.ID}", item);
        }
        
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            // var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            // item.ID = id;
            // item.AddRating(rating);

            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();
            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }
            if (_db.Items.Find(id) == null) {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null) 
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }

        
    }
}