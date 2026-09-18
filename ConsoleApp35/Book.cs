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
public static class BookExtensions
{
    public static string GetShortInfo(this Book book)
    {
        return $"{book.Title} - {book.Author} - {book.Price} AZN";
    }
    public static bool IsInStock(this Book book)
    {
        return book.StockCount > 0;
    }
    public static int ApplyDiscount(this Book book, double Percent)
    {
        if (Percent < 0 || Percent > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(Percent), " percentage must be between 0 and 100.");
        }
        double discountAmount = book.Price * (Percent / 100);
        book.Price -= discountAmount;
        return (int)book.Price;
    }
}