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
            List<Category> obj = _db.Categories.ToList();
            return View(obj);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            // kiếm tra dữ liệu khi thêm
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "displayOrder cannot exactly match the Name");
            //}
            if (ModelState.IsValid)
            {
                // thêm dữ liệu vào database
                _db.Categories.Add(obj);

                // lưu dữ liệu khi thêm
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();



        }



    }
}
