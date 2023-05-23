using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new(new EfDestinationDal());
        public IActionResult Index()
        {
            var destinations = destinationManager.TGetList();
            return View(destinations);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination model)
        {
            destinationManager.TAdd(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int Id)
        {
            var destination = destinationManager.TGetByID(Id);
            destinationManager.TDelete(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int Id)
        {
            var destination = destinationManager.TGetByID(Id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination model)
        {
            destinationManager.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
