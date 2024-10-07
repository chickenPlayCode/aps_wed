
using Microsoft.AspNetCore.Mvc;
using BaiKiemTra03_02.Data;

namespace ProjectA.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.ToList(); // Lấy danh sách tác giả
            ViewBag.Authors = authors;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(author); // Thêm tác giả
                _db.SaveChanges(); // Lưu lại thông tin
                return RedirectToAction("Index"); // Chuyển về trang index
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Update(author); // Cập nhật thông tin tác giả
                _db.SaveChanges(); // Lưu lại thông tin
                return RedirectToAction("Index"); // Chuyển về trang index
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(author); // Xóa tác giả
            _db.SaveChanges(); // Lưu lại thay đổi
            return RedirectToAction("Index"); // Chuyển về trang index
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Tìm kiếm tác giả theo tên
                var authors = _db.Authors
                    .Where(a => a.AuthorName.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
                ViewBag.Authors = authors;
            }
            else
            {
                var authors = _db.Authors.ToList();
                ViewBag.Authors = authors;
            }
            return View("Index");
        }
    }
}
