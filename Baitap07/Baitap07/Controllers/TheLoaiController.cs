﻿using Baitap07.Data;
using Baitap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap07.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            _db.TheLoai.Add(theloai);
            // Lưu lại
            _db.SaveChanges();
            return View();
        }
    }
}
