using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler;

public class GetCastByIdQueryHandler:IRequestHandler<GetCastByIdQuery,GetCastByIdQueryResult>
{
    private readonly MovieContext _context;

    public GetCastByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Casts.FindAsync(request.CastId);
        return new GetCastByIdQueryResult
        {
            CastId = values.CastId,
            Name = values.Name,
            Surname = values.Surname,
            Title = values.Title,
            Biography = values.Biography,
            ImageUrl = values.ImageUrl,
            Overview = values.Overview,
        };
    }
}