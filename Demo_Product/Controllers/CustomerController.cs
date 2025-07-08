using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
           
            List<SelectListItem> values = (from x in jobManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.JobID.ToString()
                                          }).ToList(); //list selectlist ıtem diyorum ıtemlerı listeye koy ve bunu valuese koy ama bu veriler nereden gelecek from yani  job managerda listelediğin verileri yani meslekleri x e at sonra o xden verileri seç ve valuese aktar
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid) // yani işlemler doğruysa
            {
                customerManager.TInsert(p);
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

        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {

            List<SelectListItem> values = (from x in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList(); //list selectlist ıtem diyorum ıtemlerı listeye koy ve bunu valuese koy ama bu veriler nereden gelecek from yani  job managerda listelediğin verileri yani meslekleri x e at sonra o xden verileri seç ve valuese aktar
            ViewBag.v = values;
            var value = customerManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {

            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult result = new ValidationResult();
            if (result.IsValid)
            {

                customerManager.TUpdate(c);
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
