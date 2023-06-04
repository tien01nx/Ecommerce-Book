using example.Models;
using example_web_mvc.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;


namespace example_web_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DemoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _db.Categories.ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _db.Categories.Update(category);
            _db.SaveChanges();

            return NoContent();
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();

            return category;
        }
    }
}
