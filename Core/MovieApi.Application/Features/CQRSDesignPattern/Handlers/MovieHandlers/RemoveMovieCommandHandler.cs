using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class RemoveMovieCommandHandler
{
    private readonly MovieContext _context;

    public RemoveMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        _context.Movies.Remove(value);
        await _context.SaveChangesAsync();
    }
}