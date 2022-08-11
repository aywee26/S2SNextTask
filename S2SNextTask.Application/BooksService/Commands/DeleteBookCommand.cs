using Ardalis.GuardClauses;
using MediatR;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Application.BooksService.Commands;

public record DeleteBookCommand(Guid Id) : IRequest<Book?>
{
    public class Handler : IRequestHandler<DeleteBookCommand, Book?>
    {
        private readonly IBooksRepository _booksRepository;

        public Handler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book?> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request, nameof(request));

            var entity = await _booksRepository.GetBookByIdAsync(request.Id, cancellationToken);
            if (entity is null)
            {
                return null;
            }

            await _booksRepository.DeleteBookAsync(entity, cancellationToken);
            return entity;
        }
    }
}
