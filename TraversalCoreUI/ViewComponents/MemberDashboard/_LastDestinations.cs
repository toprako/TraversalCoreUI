using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.MemberDashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = _destinationService.TGetLastFourDestinations();
            return View(destinations);
        }
    }
}
