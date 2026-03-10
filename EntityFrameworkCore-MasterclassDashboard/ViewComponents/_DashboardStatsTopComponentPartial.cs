using EntityFrameworkCore_MasterclassDashboard.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardStatsTopComponentPartial : ViewComponent
    {
        private readonly MasterclassContext _context;

        public _DashboardStatsTopComponentPartial(MasterclassContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.maxOrderPrice = _context.Orders.Max(x=>x.TotalPrice).ToString("F2");
            ViewBag.minOrderPrice = _context.Orders.Min(x=>x.TotalPrice).ToString("F2");
            ViewBag.sumOrderPrice = _context.Orders.Sum(x=>x.TotalPrice).ToString("F2");
            ViewBag.avgOrderPrice = _context.Orders.Average(x=>x.TotalPrice).ToString("F2");

            ViewBag.totalCustomerBalance = _context.Customers.Sum(x => x.CustomeBalance).ToString("F2");
            ViewBag.totalStockValue = _context.Products.Sum(x => x.ProductStock * x.ProductPrice).ToString("F2");
            ViewBag.maxProductPrice = _context.Products.Max(x => x.ProductPrice).ToString("F2");
            return View();
        }
    }
}
