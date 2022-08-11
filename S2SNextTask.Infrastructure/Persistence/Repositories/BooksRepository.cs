using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Infrastructure.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Book> _set;
        private readonly IQueryable<Book> _query;

        public BooksRepository(AppDbContext db)
        {
            _db = Guard.Against.Null(db, nameof(db));
            _set = _db.Books;
            _query = _set;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken token = default)
        {
            var result = await _query.ToListAsync(token);
            return result;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken token = default)
        {
            var result = await _set.FindAsync(new object[] { id }, token);
            return result;
        }

        public async Task<Book?> DeleteBookAsync(Book entity, CancellationToken token = default)
        {
            Guard.Against.Null(entity, nameof(entity));

            var result = _set.Remove(entity);
            await _db.SaveChangesAsync(token);

            return result.Entity;
        }


    }
}
