using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.ViewComponents
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
