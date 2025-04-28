using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handler(UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.CoverImageUrl = command.CoverImageUrl;
        value.Title = command.Title;
        value.Description = command.Description;
        value.CreatedYear=command.CreatedYear;
        value.ReleaseDate = command.ReleaseDate;
        value.Duration = command.Duration;
        value.Rating = command.Rating;
        value.Status = command.Status;
       await _context.SaveChangesAsync();
    }
}