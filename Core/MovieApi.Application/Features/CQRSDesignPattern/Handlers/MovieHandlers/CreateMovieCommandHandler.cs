using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class CreateMovieCommandHandler
{
    public readonly MovieContext _context;

    public CreateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateMovieCommand command)
    {
        _context.Movies.Add(new Movie
        {
            CoverImageUrl = command.CoverImageUrl,
            CreatedYear = command.CreatedYear,
            Title = command.Title,
            Description = command.Description,
            Duration = command.Duration,
            Rating = command.Rating,
            ReleaseDate = command.ReleaseDate,
            Status = command.Status,
        });
        await _context.SaveChangesAsync();
    }
}