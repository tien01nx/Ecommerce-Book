﻿using example.DataAccess.Repository.IRepository;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();


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
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        // delete the old imgae
                        var oldImageUrl = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImageUrl))
                        {

                            System.IO.File.Delete(oldImageUrl);

                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                    }
                    productVM.Product.ImageUrl = @"\images\product\" + filename;
                }
                if (productVM.Product.Id == 0)
                {
                    // thêm dữ liệu vào database
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }


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



        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();

        //    }


        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    Product? product1 = _db.Categories.FirstOrDefault(u => u.Id == id);
        //    Product? product2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}


        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Product.Remove(product);

        //    _unitOfWork.Save();
        //    TempData["success"] = "Delete product successfully";

        //    return RedirectToAction("Index");

        //}

        #region API CALLS

        // https://localhost:7139/admin/product/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = obj });


        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDelete = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDelete == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }

            var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDelete.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImageUrl))
            {

                System.IO.File.Delete(oldImageUrl);

            }
            _unitOfWork.Product.Remove(productToBeDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete  successful" });

        }

        #endregion

    }

}
