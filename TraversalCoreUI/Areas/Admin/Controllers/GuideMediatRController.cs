using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreUI.CQRS.Commands.GuideCommands;
using TraversalCoreUI.CQRS.Queries.DestinationQueries;
using TraversalCoreUI.CQRS.Queries.GuideQueries;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var destination = await _mediator.Send(new GetAllGuideQuery());
            return View(destination);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuides(int Id)
        {
            var guides = await _mediator.Send(new GetGuideByIdQuery() { Id = Id });
            return View(guides);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

    }
}
