
using LoginSolo.Models;
namespace LoginSolo;

public class BookRepository
{
  public List<Book> GetAllBooks()
  {
    return DataSource();
  }
  private static List<Book> DataSource()
  {
    return new List<Book>()

    {
      new Book(){Id=1,Title="Kucuk Prens",Author="Antoine de Saint-Exupery",ImagePath="/images/Kucukprens.jpg"},
      new Book(){Id=2,Title="Kucuk Prens",Author="Antoine de Saint-Exupery",ImagePath="/images/Kucukprens.jpg"},
      new Book(){Id=3,Title="Kucuk Prens",Author="Antoine de Saint-Exupery",ImagePath="/images/Kucukprens.jpg"},




  };


  }
}
