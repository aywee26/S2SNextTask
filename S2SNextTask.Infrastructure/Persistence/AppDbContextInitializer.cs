using S2SNextTask.Domain.Entities;

namespace S2SNextTask.Infrastructure.Persistence;

public class AppDbContextInitializer
{
	private readonly AppDbContext _context;

	public AppDbContextInitializer(AppDbContext context)
	{
		_context = context;
	}

	public async Task SeedAsync()
	{
		try
		{
			await TrySeedAsync();
		}
		catch (Exception ex)
		{
			throw;
		}
	}

	public async Task TrySeedAsync()
	{
		if (!_context.Books.Any())
		{
			_context.Books.AddRange(
                new Book { Author = "Ремарк Эрих", Title = "Три товарища", PublicationDate = new DateTime(1936, 12, 01) },
				new Book { Author = "Ремарк Эрих", Title = "Триумфальная арка", PublicationDate = new DateTime(1945, 01, 01) },
				new Book { Author = "Булгаков Михаил", Title = "Собачье сердце", PublicationDate = new DateTime(1987, 01, 01) },
				new Book { Author = "Булгаков Михаил", Title = "Мастер и Маргарита", PublicationDate = new DateTime(1973, 01, 01) });

			await _context.SaveChangesAsync();
		}
	}
}
