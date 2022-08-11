using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Infrastructure.Persistence.Repositories;

internal static class IQueryableExtensionMethods
{
    public static IQueryable<Book> FilterQueryByAuthor(this IQueryable<Book> query, string? author)
    {
        if (author is not null)
        {
            query = query.Where(b => b.Author.Contains(author));
        }

        return query;
    }

    public static IQueryable<Book> FilterQueryByTitle(this IQueryable<Book> query, string? title)
    {
        if (title is not null)
        {
            query = query.Where(b => b.Title.Contains(title));
        }

        return query;
    }

    public static IQueryable<Book> FilterQueryByDate(this IQueryable<Book> query, DateTime? publicationDate)
    {
        if (publicationDate is not null)
        {
            query = query.Where(b => b.PublicationDate.Equals(publicationDate));
        }

        return query;
    }

    public static IQueryable<Book> OrderByTitle(this IQueryable<Book> query)
    => query.OrderBy(b => b.Title);

    public static IQueryable<Book> OrderByAuthor(this IQueryable<Book> query)
        => query.OrderBy(b => b.Author);

    public static IQueryable<Book> OrderByDate(this IQueryable<Book> query)
        => query.OrderBy(b => b.PublicationDate);

    public static IQueryable<Book> OrderById(this IQueryable<Book> query)
        => query.OrderBy(b => b.Id);
}
