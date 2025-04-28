using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetMovieQueryResult>> Handle()
    {
        var values = await _context.Movies.ToListAsync();
        return values.Select(x => new GetMovieQueryResult
        {
            MovieId = x.MovieId,
            Title = x.Title,
            ReleaseDate = x.ReleaseDate,
            Description = x.Description,
            CoverImageUrl = x.CoverImageUrl,
            Rating = x.Rating,
            CreatedYear = x.CreatedYear,
            Duration = x.Duration,
            Status = x.Status,
        }).ToList();
    }
}