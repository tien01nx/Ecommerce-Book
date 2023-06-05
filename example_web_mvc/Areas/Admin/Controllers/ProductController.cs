using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> obj = _unitOfWork.Product.GetAll().ToList();


            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {



            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == 0 || id == null)
            {
                // create
                return View(productVM);
            }
            else
            {
                // update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                // thêm dữ liệu vào database
                _unitOfWork.Product.Add(productVM.Product);

                // lưu dữ liệu khi thêm
                _unitOfWork.Save();

                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {


                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(productVM);
            }


        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }


            Product? product = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? product1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Product? product2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);

            _unitOfWork.Save();
            TempData["success"] = "Delete product successfully";

            return RedirectToAction("Index");

        }

    }

}
