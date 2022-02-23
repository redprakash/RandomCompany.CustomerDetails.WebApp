using Microsoft.AspNetCore.Mvc;
using RandomCompany.CustomerDetails.WebApp.Models;
using RandomCompany.CustomerDetails.WebApp.Repositories;

namespace RandomCompany.CustomerDetails.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCustomer()
        {
            CustomerDetailRepositories customerDetailRepositories = new();

            return View(customerDetailRepositories.GetCustomerDetails());
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
                CustomerDetailRepositories customerDetailRepositories = new();
                if (customerDetailRepositories.CreateNewCustomer(customer))
                {
                    ViewBag.AlertMsg = "Customer Added Successfully";
                    ModelState.Clear();
                }
               
            }
            return View();
            //return View(customerDetailRepositories.CreateNewCustomer()); 
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            CustomerDetailRepositories customerDetailRepositories = new();
            return View(customerDetailRepositories.GetCustomerDetails().Find(cust => cust.Id == id));
        }
        [HttpPost]
        public IActionResult UpdateCustomer(int  id, Customer customer)
        {
            try
            {
                CustomerDetailRepositories customerDetailRepositories = new();
                customerDetailRepositories.UpdateCustomer(customer);
                ViewBag.AlertMsg = "Update Success";
                return View(customer);
                //return RedirectToAction("ViewCustomer");
            }
            catch { return View(); }
        }

        public IActionResult Details(int id)
        {
            CustomerDetailRepositories customerDetailRepositories = new();
            return View(customerDetailRepositories.GetCustomerDetails().Find(cust=>cust.Id == id));
        }



        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            CustomerDetailRepositories customerDetailRepositories = new();
            return View(customerDetailRepositories.GetCustomerDetails().Find(cust => cust.Id == id));
        }
        public IActionResult DeleteCustomer(int id,Customer customer)
        {
            try
            {
                CustomerDetailRepositories customerDetailRepositories = new();
                customerDetailRepositories.DeleteCustomer(id);
                return RedirectToAction("ViewCustomer");
            }
            catch
            {
                return View();
            }
        }

    }
}
