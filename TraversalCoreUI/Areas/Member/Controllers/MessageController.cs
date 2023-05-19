using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
