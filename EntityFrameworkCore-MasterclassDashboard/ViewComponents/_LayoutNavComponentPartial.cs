using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _LayoutNavComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
