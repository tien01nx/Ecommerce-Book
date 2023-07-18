using example.DataAccess.Repository;
using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.DTO;
using example.Models.ViewModel;
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

        // rằng buộc dữ liệu databinding
        [BindProperty]
        public ProductReviewVM ProductReviewVM { get; set; }
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

        //public IActionResult Index(string keyword, int? page)
        //{
        //    int pageNumber = page ?? 1;
        //    int pageSize = 8;

        //    IEnumerable<Product> productList;

        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages")
        //            .Where(p => p.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        //    }
        //    else
        //    {
        //        productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
        //    }

        //    var pagedProductList = productList.ToPagedList(pageNumber, pageSize);

        //    return View(pagedProductList);
        //}
        public IActionResult ProductList()
        {
            return View();
        }


        public IActionResult Index(string search, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;

            ViewBag.Page = page;

            IEnumerable<Product> productList;

            if (!string.IsNullOrEmpty(search))
            {
                productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages,Seller")
                    .Where(p => p.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || p.Seller.StoreName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages,Seller");
            }

            //foreach (var product in productList)
            //{
            //    var seller = product.Seller;
            //    Console.WriteLine(seller.StoreName); // In ra tên của cửa hàng
            //    Console.WriteLine(seller.Description); // In ra mô tả về cửa hàng
            //                                           // và cứ như vậy với các thuộc tính khác của `Seller`
            //}

            var pagedProductList = productList.ToPagedList(pageNumber, pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_Products", pagedProductList);
            }

            return View(pagedProductList);
        }

        public IActionResult Details(int productId)
        {
            var product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages,Seller");
            if (product == null)
            {
                // Handle the case where no product with the given id exists.
                // This might involve returning a 404 error, or redirecting the user to an error page.
                return NotFound();
            }

            ShoppingCart cart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages,Seller"),
                Count = 1,
                ProductId = productId
            };

            IEnumerable<ProductReview> productReviews = _unitOfWork.ProductReview.GetAll(pr => pr.Product.Id == productId, includeProperties: "ApplicationUser");

         
            // Create a new ProductReviewVM
            ProductReviewVM productReviewVM = new ProductReviewVM()
            {
                ProductReviewList = productReviews,
                ShoppingCart = cart,
                ProductReview = new ProductReview(),
                ProductId = productId,
                ApplicationUserId = User.Identity.IsAuthenticated ? ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value : null


            };


            // nếu người dùng đã đăng nhập
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                var view = new UserProductView
                {
                    ApplicationUserId = userId,
                    ProductId = product.Id,
                    ViewTime = DateTime.Now
                };

                _unitOfWork.UserProductView.Add(view);
                _unitOfWork.Save();
            }

            // nếu người chưa đăng nhập thì lưu vào Cookie
            else
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)  // cookie will expire in 30 days
                };
                // Create a new cookie for the product view
                Response.Cookies.Append($"ViewedProduct_{productId}", DateTime.Now.ToString(), cookieOptions);
            }


            return View(productReviewVM);
        }


        //[HttpPost]
        //[Authorize]
        //public IActionResult Details(ShoppingCart shoppingCart)
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    shoppingCart.ApplicationUserId = userId;
        //    // vào giỏ hàng lấy dữ liệu từ giỏ hàng từ cơ sở dữ liệu theo id người dùng hiện tại và id sản phẩm giống nhau
        //    // 
        //    ShoppingCart cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);
        //    if (cartFormDb != null)
        //    {
        //        // giỏ hàng tồn tại 
        //        // cập nhật số lượng sản phẩm trong giỏ hàng 
        //        cartFormDb.Count += shoppingCart.Count;
        //        _unitOfWork.ShoppingCart.Update(cartFormDb);
        //        _unitOfWork.Save();
        //    }
        //    else
        //    {
        //        // thêm giỏ hàng 
        //        _unitOfWork.ShoppingCart.Add(shoppingCart);
        //        _unitOfWork.Save();
        //        HttpContext.Session.SetInt32(SD.SessionCart,
        //            _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

        //    }
        //    TempData["success"] = "Cart updated successfully";

        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost]
        [Authorize]
        public IActionResult Details(ProductReviewVM productReviewVM)
        {


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            productReviewVM.ShoppingCart.ApplicationUserId = userId;


            // vào giỏ hàng lấy dữ liệu từ giỏ hàng từ cơ sở dữ liệu theo id người dùng hiện tại và id sản phẩm giống nhau
            ShoppingCart cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == productReviewVM.ProductId);
            if (cartFormDb != null)
            {
                // giỏ hàng tồn tại 
                // cập nhật số lượng sản phẩm trong giỏ hàng 
                cartFormDb.Count += productReviewVM.ShoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFormDb);
                _unitOfWork.Save();
            }
            else
            {
                // thêm giỏ hàng 
                _unitOfWork.ShoppingCart.Add(productReviewVM.ShoppingCart);
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


        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
        //    return Json(productList, new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve
        //    });
        //}
        // tim kiem


        [HttpGet]
        public IActionResult GetProducts()
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
                    ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList()
                });

            return Json(productList);
        }


        public IActionResult ViewedProducts()
        {
            var viewedProductIds = new List<int>();

            // Iterate over all cookies
            foreach (var cookie in Request.Cookies)
            {
                if (cookie.Key.StartsWith("ViewedProduct_"))
                {
                    // Get the product id from the cookie key
                    var productId = int.Parse(cookie.Key.Substring("ViewedProduct_".Length));
                    viewedProductIds.Add(productId);
                }
            }

            // Fetch the products from the database using the repository
            var productDTOs = new List<ProductDTO>();
            foreach (var productId in viewedProductIds)
            {
                var product = _unitOfWork.UserProductView.GetProductById(productId);
                if (product != null)
                {
                    // Map Product to ProductDTO
                    var productDTO = new ProductDTO
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Author = product.Author,
                        ListPrice = product.ListPrice,
                        ProductImages = product.ProductImages.Select(image => new ProductImage
                        {
                            Id = image.Id,
                            ImageUrl = image.ImageUrl
                        }).ToList(),
                        // Map các trường khác
                    };
                    productDTOs.Add(productDTO);
                }
            }

            // Return the list of product DTOs as a JSON object
            return Json(productDTOs);
        }




    }
}