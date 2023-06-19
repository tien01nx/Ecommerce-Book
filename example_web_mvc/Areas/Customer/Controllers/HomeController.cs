using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Security.Claims;
using X.PagedList;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //public IActionResult Index()
        //{

        //    IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");


        //    return View(productList);
        //}
        //public IActionResult Index(string keyword)
        //{
        //    IEnumerable<Product> productList;

        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages")
        //            .Where(p => p.Title.Contains(keyword));
        //    }
        //    else
        //    {
        //        productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
        //    }

        //    return View(productList);
        //}

        public IActionResult Index(string keyword, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;

            IEnumerable<Product> productList;

            if (!string.IsNullOrEmpty(keyword))
            {
                productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages")
                    .Where(p => p.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
            }

            var pagedProductList = productList.ToPagedList(pageNumber, pageSize);

            return View(pagedProductList);
        }


        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };


            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;
            // vào giỏ hàng lấy dữ liệu từ giỏ hàng từ cơ sở dữ liệu theo id người dùng hiện tại và id sản phẩm giống nhau
            // 
            ShoppingCart cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);
            if (cartFormDb != null)
            {
                // giỏ hàng tồn tại 
                // cập nhật số lượng sản phẩm trong giỏ hàng 
                cartFormDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFormDb);
                _unitOfWork.Save();
            }
            else
            {
                // thêm giỏ hàng 
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

            }
            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}