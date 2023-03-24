using Exercise1.Models;
using Exercise1.ViewModels;
using System; // test3 pt2
using System.Collections.Generic;
using System.Data.Entity; // ep30
using System.Data.Entity.Validation; // test3 pt2
using System.Linq;
using System.Web.Mvc;

namespace Exercise1.Controllers
{
    public class CustomersController : Controller
    {
        // add the customers by the db in ep29
        // if I want, I can add readonly after private
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            // var customers = GetCustomers();
            // ep28
            // var customers = _context.Customers.ToList();
            // ep30
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            // ep29
            // var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // test2.2
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // after ep29 this is not used
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };

        }

        // ep38
        public ActionResult New()
        {
            // ep40 start
            var membershipTypes = _context.MembershipTypes.ToList();

            var ViewModel = new CustomerFormViewModels
            {
                // add customer ep55
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            //ep43
            //return View(ViewModel)
            return View("CustomerForm", ViewModel);
            // end
            //return View();
        }

        // Ep41

        [HttpPost]
        //public ActionResult Create(NewCustomerViewModel viewModel)
        public ActionResult Create(Customer customer)
        {
            // Ep41
            _context.Customers.Add(customer); // -> save in the cache
            _context.SaveChanges(); // -> save in the db

            return RedirectToAction("Index", "Customers");
            // return View();
        }

        // ep58
        [ValidateAntiForgeryToken]
        // ep44
        public ActionResult Save(Customer customer)
        {
            // ep50
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModels
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                // Add the viewModel in the return of the view, without it gives the error of model = null
               return View("CustomerForm", viewModel);
                // return RedirectToAction("Index", "Customers");
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer); // -> save in the cache
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDb);
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email"});

                // Mapper.Map(customer, customerInDb); -> public ActionResult Save(UpdateCustomerDto customer)

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            // it's not the same problem of movie, it gives back an error in Data
            _context.SaveChanges(); // -> save in the db

            return RedirectToAction("Index", "Customers");
            // return View();
        }

        // Ep43
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModels
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            // return View("New", viewModel);
            return View("CustomerForm", viewModel);
        }
    }
}