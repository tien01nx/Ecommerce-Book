using example_web_mvc.Data;
using example_web_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Controllers
{
 
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> obj =_db.Categories.ToList();
            return View(obj);
        }

       
    }
}
