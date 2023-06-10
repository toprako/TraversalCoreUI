using DataAccessLayer.Concrete;
using TraversalCoreUI.CQRS.Commands.DestinationCommands;

namespace TraversalCoreUI.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var destination = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(destination);
            _context.SaveChanges();
        }
    }
}
