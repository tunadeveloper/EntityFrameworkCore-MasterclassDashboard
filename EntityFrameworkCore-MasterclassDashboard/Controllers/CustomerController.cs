using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MasterclassContext _context;

        public CustomerController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page, string searchString)
        {
            var customers = _context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
                customers = customers.Where(x => x.CustomeName.Contains(searchString) || x.CustomeSurname.Contains(searchString));

            var model = customers.OrderBy(x => x.Id).ToPagedList(page ?? 1, 10);

            ViewBag.totalCustomer = _context.Customers.Count().ToString("N0");
            ViewBag.totalBalance = _context.Customers.Sum(x => x.CustomeBalance).ToString("N2");
            ViewBag.activeCustomer = _context.Customers.Count(x => x.IsActive).ToString("N0");
            ViewBag.Search = searchString;

            return View(model);
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            _context.Customers.Remove(values);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
