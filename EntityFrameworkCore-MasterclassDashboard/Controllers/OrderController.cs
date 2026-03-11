using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class OrderController : Controller
    {
        private readonly MasterclassContext _context;

        public OrderController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page, string searchString)
        {
            var orders = _context.Orders
                .Include(x => x.Product)
                .Include(x => x.Customer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                orders = orders.Where(x =>
                    x.Product.ProductName.Contains(searchString) ||
                    x.Customer.CustomeName.Contains(searchString) ||
                    x.Customer.CustomeSurname.Contains(searchString));

            var model = orders.OrderBy(x => x.Id).ToPagedList(page ?? 1, 10);

            ViewBag.totalOrder    = _context.Orders.Count().ToString("N0");
            ViewBag.totalRevenue  = _context.Orders.Sum(x => x.TotalPrice).ToString("N2");
            ViewBag.totalSaleCount = _context.Orders.Sum(x => x.SaleCount).ToString("N0");
            ViewBag.Search = searchString;

            return View(model);
        }

        public IActionResult CreateOrder()
        {
            ViewBag.productList  = new SelectList(_context.Products.ToList(), "Id", "ProductName");
            ViewBag.customerList = new SelectList(_context.Customers.ToList(), "Id", "CustomeName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateOrder(int id)
        {
            var values = _context.Orders.Find(id);
            ViewBag.productList  = new SelectList(_context.Products.ToList(), "Id", "ProductName", values.ProductId);
            ViewBag.customerList = new SelectList(_context.Customers.ToList(), "Id", "CustomeName", values.CustomerId);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteOrder(int id)
        {
            var values = _context.Orders.Find(id);
            _context.Orders.Remove(values);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
