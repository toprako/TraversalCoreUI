using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreUI.CQRS.Queries.DestinationQueries;
using TraversalCoreUI.CQRS.Results.DestinationResults;

namespace TraversalCoreUI.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle(GetAllDestinationQuery query)
        {
            return _context.Destinations.Select(x => new GetAllDestinationQueryResult()
            {
                Id = x.DestinationID,
                Capacity = x.Capacity,
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
        }
    }
}
