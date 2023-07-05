using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductReviewController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }


        public ProductReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateReview(ProductReviewVM productReviewVM)
        {

            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            // Create new ProductReview
            // xác thực người dùng chưa đăng nhập 
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/Identity/Account/Login?ReturnUrl=/Customer/Home/Details/?productId={productReviewVM.ProductId}");

            }
            var newReview = new ProductReview
            {
                Rating = productReviewVM.ProductReview.Rating,
                Comment = productReviewVM.ProductReview.Comment,
                DateCreated = DateTime.Now,
                ProductId = productReviewVM.ProductId,
                ApplicationUserId = productReviewVM.ApplicationUserId

            };

            // Insert into database
            _unitOfWork.ProductReview.Add(newReview);
            _unitOfWork.Save();

            TempData["success"] = "Review created successfully";


            // If ModelState is invalid, you might want to handle differently
            return RedirectToAction(nameof(HomeController.Details), "Home", new { productId = productReviewVM.ProductId });

        }

        [HttpGet]
        [Authorize]
        public IActionResult EditReview(int reviewId)
        {
            var review = _unitOfWork.ProductReview.Get(u => u.Id == reviewId);




            if (review != null)
            {
                var productReviewVM = new ProductReviewVM
                {
                    ProductId = review.ProductId,
                    ProductReview = new ProductReview
                    {
                        Id = review.Id,
                        Rating = review.Rating,
                        Comment = review.Comment
                    }
                };

                return View(productReviewVM);
            }

            // Nếu không tìm thấy đánh giá hoặc không có quyền chỉnh sửa, chuyển hướng đến trang chi tiết sản phẩm
            return RedirectToAction(nameof(HomeController.Details), "Home", new { productId = review.ProductId });
        }


    }
}
