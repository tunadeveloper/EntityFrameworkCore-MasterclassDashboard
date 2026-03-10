using EntityFrameworkCore_MasterclassDashboard.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardChartComponentPartial : ViewComponent
    {
        private readonly MasterclassContext _context;

        public _DashboardChartComponentPartial(MasterclassContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var thisYear = DateTime.Now.Year;
            var ordersThisYear = _context.Orders.Where(x => x.CreatedDate.Year == thisYear);

            ViewBag.ChartSalesData = Enumerable.Range(1, 12)
                .Select(x => (double)ordersThisYear.Where(y => y.CreatedDate.Month == x).Sum(z => z.TotalPrice))
                .ToList();
            ViewBag.ChartPurchaseData = Enumerable.Range(1, 12).Select(x => 0.0).ToList();

            ViewBag.totalCustomersCount = _context.Customers.Count();
            ViewBag.totalOrdersCount = _context.Orders.Count();
            ViewBag.totalProductsCount = _context.Products.Count();
            ViewBag.minCustomerBalance = _context.Customers.Min(x => x.CustomeBalance).ToString("N2");
            ViewBag.maxCustomerBalance = _context.Customers.Max(x => x.CustomeBalance).ToString("N2");

            return View();
        }
    }
}
