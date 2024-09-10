using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BaiTapKiemTra01.Controllers
{
    public class DangKyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login(TaiKhoanViewModel TaiKhoan)
        {
            if (TaiKhoan.TenTaiKhoan != null)  
    {
                return Content(TaiKhoan.TenTaiKhoan);
            }
            return View();
        }
        public IActionResult BaiTap2()
        {
            // Tạo một đối tượng SanPhamViewModel với dữ liệu mẫu
            var sanPham = new SanPhamViewModel
            {
                TenSanPham = "Sản phẩm mẫu",
                GiaBan = 100000,
                AnhMoTa = "/images/about-img.jpg" // Đường dẫn đến ảnh mô tả
            };

            // Truyền đối tượng đến view
            return View(sanPham);
        }
    }
}
