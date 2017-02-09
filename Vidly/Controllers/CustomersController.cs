using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var Customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            return View(Customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer> {
                 new Customer {Id=1, Name = "John Doe"},
                new Customer {Id=2, Name = "Rahul Singh"}
            };

            return customers;
        }
    }
}