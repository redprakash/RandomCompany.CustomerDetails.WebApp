using Microsoft.AspNetCore.Mvc;
using RandomCompany.CustomerDetails.WebApp.Models;
using RandomCompany.CustomerDetails.WebApp.Repositories;

namespace RandomCompany.CustomerDetails.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDetailRepositories _customerDetailRepositories;
        public CustomerController(CustomerDetailRepositories repositories)
        {
            _customerDetailRepositories = repositories;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCustomer()
        {

            return View(_customerDetailRepositories.GetAllCustomers());
        }

        //Get AddCustomer form pagte
        public IActionResult AddCustomer()
        {
            return View();
        }

        // Post AddCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerDetailRepositories.CreateNewCustomer(customer);
                ViewBag.AlertMsg = "Customer Added Successfully";
                ModelState.Clear();
            }
            return View();
            //return View(customerDetailRepositories.CreateNewCustomer()); 
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {

            return View(_customerDetailRepositories.GetAllCustomers().Find(cust => cust.Id == id));
        }
        [HttpPost]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            try
            {
                _customerDetailRepositories.UpdateCustomer(customer);
                ViewBag.AlertMsg = "Update Success";
                return View(customer);
                //return RedirectToAction("ViewCustomer");
            }
            catch { return View(); }
        }

        public IActionResult Details(int id)
        {

            return View(_customerDetailRepositories.GetAllCustomers().Find(cust => cust.Id == id));
        }



        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {

            return View(_customerDetailRepositories.GetAllCustomers().Find(cust => cust.Id == id));
        }
        public IActionResult DeleteCustomer(int id, Customer customer)
        {
            try
            {

                _customerDetailRepositories.DeleteCustomer(id);
                return RedirectToAction("ViewCustomer");
            }
            catch
            {
                return View();
            }
        }

    }
}
