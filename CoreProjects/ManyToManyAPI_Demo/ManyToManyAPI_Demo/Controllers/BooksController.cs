using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneToManyAPI_Demo.Models;

namespace OneToManyAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context
                .Books.Include(b => b.BookOrders)
                .ThenInclude(bo => bo.Order)
                .ToListAsync();
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooks), new { id = book.BookId }, book);
        }
    }
}
