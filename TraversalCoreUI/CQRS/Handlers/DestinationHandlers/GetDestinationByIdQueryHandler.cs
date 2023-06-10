using DataAccessLayer.Concrete;
using TraversalCoreUI.CQRS.Queries.DestinationQueries;
using TraversalCoreUI.CQRS.Results.DestinationResults;

namespace TraversalCoreUI.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.ID);
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationID,
                City = values.City, 
                DayNight = values.DayNight,
                Price = values.Price,
            };
        }
    }
}
