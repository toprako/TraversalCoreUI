using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.AdminDashboard
{
    public class _AdminGuideList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
