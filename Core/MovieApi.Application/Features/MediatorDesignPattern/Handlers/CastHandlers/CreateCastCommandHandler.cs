using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler;

public class CreateCastCommandHandler:IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
         await _context.Casts.AddAsync(new Cast
        {
            Biography = request.Biography,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Overview = request.Overview,
            Surname = request.Surname,
            Title = request.Title,
        });
        await _context.SaveChangesAsync();
    }
}