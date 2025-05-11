using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;

public class UpdateCastCommand:IRequest
{
    public int CastId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ImageUrl { get; set; }
    public string? Overview { get; set; }
    public string? Biography { get; set; }
}