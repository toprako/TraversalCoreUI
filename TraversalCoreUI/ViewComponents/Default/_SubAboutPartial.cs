using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.Default
{
    public class _SubAboutPartial : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAbountDal());
        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetList();
            return View(values);
        }
    }
}
