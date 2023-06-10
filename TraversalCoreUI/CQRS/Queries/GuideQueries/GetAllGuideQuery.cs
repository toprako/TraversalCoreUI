using MediatR;
using TraversalCoreUI.CQRS.Results.GuideResults;

namespace TraversalCoreUI.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
