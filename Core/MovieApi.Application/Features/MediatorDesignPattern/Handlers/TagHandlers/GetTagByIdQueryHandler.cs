using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandler;

public class GetTagByIdQueryHandler:IRequestHandler<GetTagByIdQuery,GetTagByIdQueryResult>
{
    private readonly MovieContext _context;

    public GetTagByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Tags.FindAsync(request.TagId);
        return new GetTagByIdQueryResult
        {
            Title = values.Title
        };
        
    }
}