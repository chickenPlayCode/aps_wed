using BaiKiemTra03_02.Models;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int BookId { get; set; }

    [Required(ErrorMessage = "Tiêu đề sách là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Tiêu đề không được dài hơn 100 ký tự.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Năm xuất bản là bắt buộc.")]
    [Range(1500, 2024, ErrorMessage = "Năm xuất bản phải nằm trong khoảng từ 1500 đến năm hiện tại.")]
    public int PublicationYear { get; set; }

    // Khóa ngoại AuthorId
    [Required(ErrorMessage = "Tác giả là bắt buộc.")]
    public int AuthorId { get; set; }

    // Liên kết với Author
    public Author Author { get; set; }

    [Required(ErrorMessage = "Thể loại là bắt buộc.")]
    public string Genre { get; set; }
}