using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

public class GetCastQuery:IRequest<List<GetCastQueryResult>>, IRequest<List<GetCastQueryHandler>>
{
    
}