using S2SNextTask.Domain.Entities;
using S2SNextTask.Domain.Enums;

namespace S2SNextTask.Application.Common.Interfaces.Persistence;

public interface IBooksRepository
{
    Task<Book?> GetBookByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken token = default);
    Task<IEnumerable<Book>> GetFilteredBooksAsync(string? title = null, string? author = null, DateTime? publicationDate = null, BooksOrderEnum order = BooksOrderEnum.Id, CancellationToken token = default);


    Task<Book?> DeleteBookAsync(Book entity, CancellationToken token = default);
}
