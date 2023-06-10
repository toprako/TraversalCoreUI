using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreUI.CQRS.Commands.DestinationCommands;
using TraversalCoreUI.CQRS.Handlers.DestinationHandlers;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateDestinationCommadHandler _createDestinationCommadHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommadHandler createDestinationCommadHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _createDestinationCommadHandler = createDestinationCommadHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle(new CQRS.Queries.DestinationQueries.GetAllDestinationQuery());
            return View(values );
        }

        [HttpGet]
        public IActionResult GetDestination(int Id)
        {
            var destinations = _getDestinationByIdQueryHandler.Handle(new() { ID = Id });
            return View(destinations);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommad commad)
        {
            _createDestinationCommadHandler.Handle(commad);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int Id)
        {
            _removeDestinationCommandHandler.Handle(new() { Id = Id});
            return RedirectToAction("Index");
        }
    }
}
