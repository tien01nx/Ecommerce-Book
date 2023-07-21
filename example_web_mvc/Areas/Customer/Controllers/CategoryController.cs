using example.DataAccess.Repository.IRepository;
using example.Models;
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
    }
}
