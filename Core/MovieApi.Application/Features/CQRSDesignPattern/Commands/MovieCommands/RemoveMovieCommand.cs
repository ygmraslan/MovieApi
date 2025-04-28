namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;

public class RemoveMovieCommand
{
    public RemoveMovieCommand(int movieid)
    {
       MovieId = movieid; 
    }
    public int MovieId { get; set; }
}