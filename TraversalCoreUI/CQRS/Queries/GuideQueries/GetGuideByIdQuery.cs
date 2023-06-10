using MediatR;
using TraversalCoreUI.CQRS.Results.GuideResults;

namespace TraversalCoreUI.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public int Id { get; set; } 
    }
}
