using Ardalis.GuardClauses;
using MediatR;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Application.BooksService.Queries;

public record GetBookByIdQuery(Guid Id) : IRequest<Book?>
{
    public class Handler : IRequestHandler<GetBookByIdQuery, Book?>
    {
        private readonly IBooksRepository _booksRepository;

        public Handler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request, nameof(request));

            var result = await _booksRepository.GetBookByIdAsync(request.Id, cancellationToken);
            return result;
        }
    }
}
