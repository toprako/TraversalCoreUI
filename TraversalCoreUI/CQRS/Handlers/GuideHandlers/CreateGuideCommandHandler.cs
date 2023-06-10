using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreUI.CQRS.Commands.GuideCommands;

namespace TraversalCoreUI.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new()
            {
                Description = request.Description,
                Image = request.Image ?? "",
                Name = request.Name,    
                Status = true,    
                InstagramUrl = "",
                TwitterUrl = "",
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
