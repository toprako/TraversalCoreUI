using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.MemberDashboard
{
    public class _GuideListMemberDashboard : ViewComponent
    {
        GuideManager guideManager = new(new EfGuideDal());

        public IViewComponentResult Invoke()
        {
            var guides = guideManager.TGetList();
            return View(guides);
        }
    }
}
