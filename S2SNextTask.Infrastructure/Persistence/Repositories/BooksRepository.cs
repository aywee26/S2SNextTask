using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Infrastructure.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> DeleteBookAsync(Book entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }


    }
}
