using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _DashboardChartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
