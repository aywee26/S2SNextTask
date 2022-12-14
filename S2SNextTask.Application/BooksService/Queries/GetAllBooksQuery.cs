using Ardalis.GuardClauses;
using MediatR;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Application.BooksService.Queries;

public record GetAllBooksQuery : IRequest<IEnumerable<Book>>
{
    public class Handler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBooksRepository _booksRepository;

        public Handler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request, nameof(request));

            var result = await _booksRepository.GetAllBooksAsync(cancellationToken);
            return result;
        }
    }
}
