using LoginSolo.Data;
using LoginSolo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoginSolo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DataContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<List<Book>> GetSampleBooks()
        {
            var books = await _context.Books.ToListAsync();

            return books;

        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = await GetSampleBooks();
            return View(books);


        }



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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> BookDetail(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return View(book);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id, bool like)
        {
            var book = await _context.Books.FindAsync(id);

            if (like)
                book.NumberOfLikes++;


            await _context.SaveChangesAsync();

            var updatedBooks = await _context.Books.ToListAsync();
            return Json(updatedBooks);
        }

    }
}
