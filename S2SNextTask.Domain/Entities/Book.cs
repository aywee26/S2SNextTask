namespace S2SNextTask.Domain.Entities;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Author { get; set; } = default!;
    public string Title { get; set; } = default!;
    public DateTime PublicationDate { get; set; } = new();
}
