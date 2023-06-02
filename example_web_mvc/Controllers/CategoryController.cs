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
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();



        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }


            Category? category = _db.Categories.Find(id);
            //Category? category1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {


            if (ModelState.IsValid)
            {
                // thêm dữ liệu vào database
                _db.Categories.Update(obj);

                // lưu dữ liệu khi thêm
                _db.SaveChanges();
                TempData["success"] = "Category update successfully";
                return RedirectToAction("Index");
            }

            return View();

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }


            Category? category = _db.Categories.Find(id);
            //Category? category1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);

            _db.SaveChanges();
            TempData["success"] = "Delete category successfully";

            return RedirectToAction("Index");

        }




    }
}
