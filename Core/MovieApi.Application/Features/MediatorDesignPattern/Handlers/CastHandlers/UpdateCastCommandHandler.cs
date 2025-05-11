using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler;

public class UpdateCastCommandHandler: IRequestHandler<UpdateCastCommand>
{
    private readonly MovieContext _context;

    public UpdateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        var values = await _context.Casts.FindAsync(request.CastId);
        values.Name = request.Name;
        values.Surname = request.Surname;
        values.ImageUrl = request.ImageUrl;
        values.Title = request.Title;
        values.Biography = request.Biography;
        values.Overview = request.Overview;
        await _context.SaveChangesAsync();
    }
}