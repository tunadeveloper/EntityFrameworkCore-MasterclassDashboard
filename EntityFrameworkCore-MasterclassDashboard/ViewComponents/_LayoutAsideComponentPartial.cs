using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _LayoutAsideComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
