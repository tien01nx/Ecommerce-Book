using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            dynamic myModel = new ExpandoObject();
            myModel.CategoryName = _unitOfWork.Category.GetAll().ToList();
            myModel.AuthorTop8 = _unitOfWork.Product.GetTopOrderedProducts().Take(8);
            myModel.ProductAll = _unitOfWork.Product.GetAll(includeProperties: "Category,Seller,ProductImages").Take(12).ToList();
            return View(myModel);

        }
     

        [HttpGet]
        public IActionResult GetCategoryProduct()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages,Seller")
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    ListPrice = p.ListPrice,
                    Price100 = p.Price100,
                    StoreName = p.Seller.StoreName,
                    // Extract the image URLs
                    ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
                });

            return Json(productList);
        }


        [HttpGet]
        public IActionResult GetCategoryProducthehe(List<string> authors)
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category,Seller,ProductImages")
                                .Where(p => authors.Contains(p.Author))
                                .ToList();

            // convert to a format suitable for your front-end
            var result = products.Select(p => new {
                id = p.Id,
                title = p.Title,
                author = p.Author,
                price100 = p.Price100,
                imageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList()
            }).ToList();

            return Json(result);
        }

    }
}
