namespace LoginSolo.Models;

public class Book
{

  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Author { get; set; }
  public string? ImagePath { get; set; }
  public int? Pages { get; set; }

  public string? Info { get; set; }
  public string? Genres { get; set; }
  public int? NumberOfLikes { get; set; }
  // Diğer kitap özellikleri eklenebilir
}


