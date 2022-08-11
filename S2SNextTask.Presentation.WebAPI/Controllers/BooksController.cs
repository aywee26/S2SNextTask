using MediatR;
using Microsoft.AspNetCore.Mvc;
using S2SNextTask.Application.BooksService.Commands;
using S2SNextTask.Application.BooksService.Queries;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Presentation.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BooksController : Controller
{
    private readonly ISender _mediator;

    public BooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ActionName("books")]
    public async Task<IEnumerable<Book>> GetAllBooks(CancellationToken token)
    {
        var result = await _mediator.Send(new GetAllBooksQuery(), token);
        return result;
    }

    [HttpGet]
    [ActionName("search")]
    public async Task<IEnumerable<Book>> GetFilteredBooks(string? title, string? author, CancellationToken token)
    {
        var result = await _mediator.Send(new GetFilteredBooksQuery(title, author), token);
        return result;
    }

    [HttpPost]
    [ActionName("books/{id}")]
    public async Task<Book> BuyBook([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new DeleteBookCommand(id), token);
        return result;
    }
}
