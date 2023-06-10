﻿using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalCoreUI.CQRS.Queries.GuideQueries;
using TraversalCoreUI.CQRS.Results.GuideResults;

namespace TraversalCoreUI.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideId = x.GuideID,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();
        }
    }
}
