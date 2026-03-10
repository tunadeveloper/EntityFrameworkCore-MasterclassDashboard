using EntityFrameworkCore_MasterclassDashboard.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MasterclassContext _context;

        public StatisticsController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult OrderStatistics()
        {
            ViewBag.totalOrderCount = _context.Orders.Count();
            ViewBag.totalOrderBalance = _context.Orders.Sum(x => x.TotalPrice).ToString("N2");
            ViewBag.avgOrderBalance = _context.Orders.Average(x => x.TotalPrice).ToString("N2");
            ViewBag.totalOrderQuantity = _context.Orders.Sum(x => x.SaleCount);

            ViewBag.minOrderBalance = _context.Orders.Min(x => x.TotalPrice).ToString("N2");
            ViewBag.maxOrderBalance = _context.Orders.Max(x => x.TotalPrice).ToString("N2");
            ViewBag.avgUnitPrice = _context.Orders.Average(x => x.UnitPrice).ToString("N2");

            var values = _context.Orders.OrderByDescending(x=>x.CreatedDate).Take(7).ToList();
            return View(values);
        }

        public IActionResult ProductStatistics()
        {
            ViewBag.productCount = _context.Products.Count();
            ViewBag.totalStockAmount = _context.Products.Sum(x => x.ProductStock * x.ProductPrice).ToString("N2");
            ViewBag.avgOrderAmount = _context.Products.Average(x => x.ProductPrice).ToString("N2");
            ViewBag.totalProductStock = _context.Products.Sum(x => x.ProductStock).ToString("N0");

            ViewBag.lowProductPrice = _context.Products.Min(x => x.ProductPrice).ToString("N2");
            ViewBag.highProductPrice = _context.Products.Max(x => x.ProductPrice).ToString("N2");
            ViewBag.lowProductStock = _context.Products.Min(y => y.ProductStock);

            ViewBag.categoryDistribution = _context.Categories.Select(x=> new
            {
                Name = x.CategoryName,
                Count = x.Products.Count()
            }).Take(5).OrderByDescending(x=>x.Count).ToDictionary(x => x.Name, x => x.Count);
            ViewBag.latestOrderProduct = _context.Orders.Include(x => x.Product).ThenInclude(z=>z.Category).OrderByDescending(y => y.CreatedDate).Take(6).ToList();
            return View();
        }
    }
}
