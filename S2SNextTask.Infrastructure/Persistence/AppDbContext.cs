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
        builder.Entity<Book>().HasKey(b => b.Id);
        builder.Entity<Book>().Property(b => b.Title).HasMaxLength(200).IsRequired();
        builder.Entity<Book>().Property(b => b.Author).HasMaxLength(200).IsRequired();
        builder.Entity<Book>().Property(b => b.PublicationDate).IsRequired();
        base.OnModelCreating(builder);
    }
}
