using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardTablesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
