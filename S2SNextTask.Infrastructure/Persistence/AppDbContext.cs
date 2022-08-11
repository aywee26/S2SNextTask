using Microsoft.EntityFrameworkCore;
using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasData(
            new Book { Author = "Ремарк Эрих", Title = "Три товарища", PublicationDate = new DateTime(1936, 12, 01) },
            new Book { Author = "Ремарк Эрих", Title = "Триумфальная арка", PublicationDate = new DateTime(1945, 01, 01) });
    }
}
