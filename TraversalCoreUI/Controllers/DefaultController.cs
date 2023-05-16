using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
