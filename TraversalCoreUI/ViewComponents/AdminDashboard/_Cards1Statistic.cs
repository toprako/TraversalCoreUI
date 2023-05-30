using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.turSayı = context.Destinations.Count();
            ViewBag.misafirSayısı = context.Users.Count();
            return View();
        }
    }
}
