using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
