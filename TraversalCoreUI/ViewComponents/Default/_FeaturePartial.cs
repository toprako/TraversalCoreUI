using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
           // ViewBag.image1 = featureManager.TGetList

            return View();
        }
    }
}
