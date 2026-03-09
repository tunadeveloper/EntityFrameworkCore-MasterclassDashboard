using EntityFrameworkCore_MasterclassDashboard.Context;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.avgCustomerBalance = _context.Customers.Average(x=>x.CustomeBalance).ToString("F2");
            return View();
        }
    }
}
