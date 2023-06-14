using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager guideManager = new(new EfGuideDal());
        public IActionResult Index()
        {
            var guides = guideManager.TGetList();
            return View(guides);
        }
    }
}
