using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TraversalCoreUI.CQRS.Commands.DestinationCommands;

namespace TraversalCoreUI.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommadHandler
    {
        private readonly Context _context;

        public CreateDestinationCommadHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommad commad)
        {
            _context.Destinations.Add(new Destination
            {
                City = commad.City,
                Price = commad.Price,
                DayNight = commad.DayNight, 
                Capacity = commad.Capacity,
                CoverImage = "",
                Description = "",
                Details1 = "",
                Details2 = "",
                Image = "",
                Image2 = "",
                Status = true,  
            });
            _context.SaveChanges();
        }

    }
}
