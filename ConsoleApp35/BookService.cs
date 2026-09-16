public interface IBookService
{
 void Add(Book book);
 void GetById(int id);
 void GetByGenre(Genre genre);
 void GetMostExpensiveBook();
void GetCheapestBook();
void GetAveragePrice();
void CountByGenre(Genre genre);
void GetByPriceRange(double min, double max);
}





public class BookService : IBookService
{
    
    public void Add(Book book)
    {
        if(books.Any(b => b.Title == book.Title && b.Author==book.Author))
        {
           throw new ConflictException("A book with the same title and author already exists.");
        }
    }
    public void GetById(int id)
    {
        if (books.Any(b => b.Id == id))
        {
            throw new NotFoundException("Book not found.");
        }
       
    }
    public void GetByGenre(Genre genre)
    {
        var booksByGenre = books.Where(b => b.Genre == genre).ToList();
        if (booksByGenre.Any())
        {
            foreach (var book in booksByGenre)
            {
                Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, PageCount: {book.PageCount}, StockCount: {book.StockCount}, Genre: {book.Genre}, CreatedAt: {book.CreatedAt}");
            }
        }
        else
        {
            Console.WriteLine("No books found for the specified genre.");
        }
    }
    public void GetMostExpensiveBook()
    {
        var mostExpensiveBook = books.OrderByDescending(b => b.Price).FirstOrDefault();
        if (mostExpensiveBook != null)
        {
            Console.WriteLine($"Most Expensive Book: Id: {mostExpensiveBook.Id}, Title: {mostExpensiveBook.Title}, Author: {mostExpensiveBook.Author}, Price: {mostExpensiveBook.Price}");
        }
        else
        {
            Console.WriteLine("No books available.");
        }
    }
    public void GetCheapestBook()
    {
        var cheapestBook = books.OrderBy(b => b.Price).FirstOrDefault();
        if (cheapestBook != null)
        {
            Console.WriteLine($"Cheapest Book: Id: {cheapestBook.Id}, Title: {cheapestBook.Title}, Author: {cheapestBook.Author}, Price: {cheapestBook.Price}");
        }
        else
        {
            Console.WriteLine("No books available.");
        }
    }
    public void GetAveragePrice()
    {
        if (books.Any())
        {
            var averagePrice = books.Average(b => b.Price);
            Console.WriteLine($"Average Price of Books: {averagePrice}");
        }
        else
        {
            Console.WriteLine("No books available to calculate average price.");
        }
    }
    public void CountByGenre(Genre genre)
    {
        var count = books.Count(b => b.Genre == genre);
        Console.WriteLine($"Number of books in {genre} genre: {count}");
    }
    public void GetByPriceRange(double min, double max)
    {
        var booksInRange = books.Where(b => b.Price >= min && b.Price <= max).ToList();
        if (booksInRange.Any())
        {
            foreach (var book in booksInRange)
            {
                Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
            }
        }
        else
        {
            Console.WriteLine("No books found in the specified price range.");
        }
    }
     public static List<Book> books = new List<Book>();
   

}