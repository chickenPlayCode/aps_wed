using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {

        private readonly ApplicationDbContext db;
        private string? searchString;

        public LopHocController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var lopHocs = from l in db.Lophoc
                          select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lopHocs = lopHocs.Where(s => s.TenLopHoc.Contains(searchString));
            }

            ViewBag.LopHoc = lopHocs.ToList();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.Lophoc.Add(lopHoc);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = db.Lophoc.Find(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(lopHoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(lopHoc);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = db.Lophoc.FirstOrDefault(m => m.Id == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var lopHoc = db.Lophoc.Find(id);
            if (lopHoc != null)
            {
                db.Lophoc.Remove(lopHoc);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: LopHoc/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = db.Lophoc.Find(id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }



    }
}
