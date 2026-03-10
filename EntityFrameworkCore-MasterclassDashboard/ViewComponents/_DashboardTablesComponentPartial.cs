using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardTablesComponentPartial : ViewComponent
    {
        private readonly MasterclassContext _context;

        public _DashboardTablesComponentPartial(MasterclassContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.bestSellingProductsList = _context.Orders.Include(x=>x.Product).OrderByDescending(y=>y.SaleCount).Take(5).ToList();
            ViewBag.lowStockProducts = _context.Products.OrderBy(x => x.ProductStock).Take(5).ToList();
            ViewBag.latestSales = _context.Orders.Include(x=>x.Product).ThenInclude(y=>y.Category).OrderByDescending(z=>z.CreatedDate).Take(5).ToList();
            return View();
        }
    }
}
