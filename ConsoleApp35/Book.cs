public class Book
{
   
    public Book(int id, string title, string author, int pageCount, int stockCount, double price, Genre genre, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Author = author;
        PageCount = pageCount;
        StockCount = stockCount;
        Price = price;
        Genre = genre;
        CreatedAt = createdAt;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public int StockCount { get; set; }
    public double Price { get; set; }
    public Genre Genre { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}