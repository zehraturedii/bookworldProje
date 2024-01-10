using LoginSolo.Data;
using LoginSolo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoginSolo.Controllers
{
  public class BookController : Controller
  {
    private readonly DataContext _context;

    public BookController(DataContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var books = _context.Books.ToList();
      return View(books);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("Id,Title,Author,ImagePath,Pages,Info,Genres")] Book book)
    {
      if (ModelState.IsValid)
      {
        // Model doğrulaması geçerli ise, kitabı veritabanına ekleyin
        _context.Books.Add(book);
        _context.SaveChanges();

        return RedirectToAction("Index");
      }

      // Model doğrulaması geçerli değilse, formu tekrar gösterin
      return View(book);
    }
  }
}
