namespace BaiKiemTra02.Models;

using System;
using System.ComponentModel.DataAnnotations;

    public class LopHoc
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên lớp học không được quá 100 ký tự.")]
        public string TenLopHoc { get; set; }

        [Range(2000, 2100, ErrorMessage = "Năm nhập học phải nằm trong khoảng từ 2000 đến 2100.")]
        public int NamNhapHoc { get; set; }

        [Range(2000, 2100, ErrorMessage = "Năm ra trường phải nằm trong khoảng từ 2000 đến 2100.")]
        public int NamRaTruong { get; set; }

        [Range(0, 1000, ErrorMessage = "Số lượng sinh viên phải nằm trong khoảng từ 0 đến 1000.")]
        public int SoLuongSinhVien
        {
            get; set;
        }
}

