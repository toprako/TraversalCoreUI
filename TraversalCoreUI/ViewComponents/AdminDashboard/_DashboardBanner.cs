using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
