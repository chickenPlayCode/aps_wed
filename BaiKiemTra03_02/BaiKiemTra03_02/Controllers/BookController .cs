using BaiKiemTra03_02.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_02.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sách
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
        }

        // Thêm sách
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            return View(book);
        }

        // Chỉnh sửa sách
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            return View(book);
        }

        // Xóa sách
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Xem chi tiết sách
        public IActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();

            return View(book);
        }
    }

}
