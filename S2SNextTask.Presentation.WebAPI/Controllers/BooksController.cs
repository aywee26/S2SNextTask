using MediatR;
using Microsoft.AspNetCore.Mvc;
using S2SNextTask.Application.BooksService.Queries;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Presentation.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : Controller
{
    private readonly ISender _mediator;

    public BooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var result = await _mediator.Send(new GetAllBooksQuery());
        return result;
    }
}
