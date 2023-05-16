using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var list = destinationManager.TGetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult DestinationDetails(Guid Id)
        {
            ViewBag.DestinationId = Id;
            var destination = destinationManager.TGetByID(Id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
