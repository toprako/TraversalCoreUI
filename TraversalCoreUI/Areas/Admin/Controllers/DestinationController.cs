using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var destinations = _destinationService.TGetList();
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
            _destinationService.TAdd(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int Id)
        {
            var destination = _destinationService.TGetByID(Id);
            _destinationService.TDelete(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int Id)
        {
            var destination = _destinationService.TGetByID(Id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination model)
        {
            _destinationService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
