using example.DataAccess.Repository.IRepository;
using example.Models;
using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepositoty _categoryRepo;
        public ProductController(ICategoryRepositoty db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> obj = _categoryRepo.GetAll().ToList();
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
                _categoryRepo.Add(obj);

                // lưu dữ liệu khi thêm
                _categoryRepo.Save();

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


            Category? category = _categoryRepo.Get(u => u.Id == id);
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
                _categoryRepo.Update(obj);

                // lưu dữ liệu khi thêm
                _categoryRepo.Save();
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


            Category? category = _categoryRepo.Get(u => u.Id == id);
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
            Category? category = _categoryRepo.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(category);

            _categoryRepo.Save();
            TempData["success"] = "Delete category successfully";

            return RedirectToAction("Index");

        }

    }

}
