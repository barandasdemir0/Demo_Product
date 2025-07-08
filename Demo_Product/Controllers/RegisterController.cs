using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email = model.EMail
            };
            if (model.Password == model.ConfirmPassword) // modelden gelen passwordler eşleşiyorsa
            {
                var result = await _userManager.CreateAsync(appUser, model.Password); // sonuç döndür neyin sonucu appuser sınıfı ile modelden gelen passworda ekle
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login"); //doğruysa döndür
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); //yanlışsa açıklama yap
                    }
                }
            }
            return View(model); //onlardan gelen veriyi döndür
        }
    }
}
