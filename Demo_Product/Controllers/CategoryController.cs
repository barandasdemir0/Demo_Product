using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
