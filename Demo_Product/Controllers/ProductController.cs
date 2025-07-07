using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var listValue = productManager.TGetList();
            return View(listValue);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid) // yani işlemler doğruysa
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = new ValidationResult();
            if (result.IsValid)
            {
              
                productManager.TUpdate(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
          
        }
    }
}
