using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        public IActionResult Index()
        {
            return View();
        }
    }
}
