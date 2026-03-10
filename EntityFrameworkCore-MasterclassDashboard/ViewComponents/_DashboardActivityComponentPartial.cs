using EntityFrameworkCore_MasterclassDashboard.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardActivityComponentPartial : ViewComponent
    {
        private readonly MasterclassContext _context;

        public _DashboardActivityComponentPartial(MasterclassContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Activities.OrderByDescending(x=>x.CreatedDate).Take(6).ToList();
            return View(values);
        }
    }
}

