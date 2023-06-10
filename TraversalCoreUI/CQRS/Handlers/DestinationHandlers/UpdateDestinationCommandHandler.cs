using DataAccessLayer.Concrete;
using TraversalCoreUI.CQRS.Commands.DestinationCommands;

namespace TraversalCoreUI.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        public readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationId);
            values.City = command.City;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
