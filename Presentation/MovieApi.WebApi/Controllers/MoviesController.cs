using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController: ControllerBase
{
    private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
    private readonly GetMovieQueryHandler _getMovieQueryHandler;
    private readonly CreateMovieCommandHandler _createMovieCommandHandler;
    private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
    private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

    public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
    {
        _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
        _getMovieQueryHandler = getMovieQueryHandler;
        _createMovieCommandHandler = createMovieCommandHandler;
        _updateMovieCommandHandler = updateMovieCommandHandler;
        _removeMovieCommandHandler = removeMovieCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> MovieList()
    {
        var value=await _getMovieQueryHandler.Handle();
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
    {
        await _createMovieCommandHandler.Handle(command);
        return Ok("Movie has been added successfully!");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveMovie(int id)
    {
        await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
        return Ok("Movie has been removed successfully!");
    }

    [HttpGet("GetMovie")]
    public async Task<IActionResult> GetMovie(int id)
    {
        var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
    {
        await _updateMovieCommandHandler.Handler(command);
        return Ok("Movie has been updated successfully!");
    }
}