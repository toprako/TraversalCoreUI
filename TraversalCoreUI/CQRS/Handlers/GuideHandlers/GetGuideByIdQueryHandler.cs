using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreUI.CQRS.Queries.GuideQueries;
using TraversalCoreUI.CQRS.Results.GuideResults;

namespace TraversalCoreUI.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var guides = await _context.Guides.FindAsync(request.Id);
            return new()
            {
                Id = guides.GuideID,
                Name = guides.Name,
                Description = guides.Description,
            };
        }


    }
}
