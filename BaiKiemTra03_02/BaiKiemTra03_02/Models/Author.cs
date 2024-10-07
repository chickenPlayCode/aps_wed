using System.ComponentModel.DataAnnotations;

public class Author
{
    public int AuthorId { get; set; }

    [Required(ErrorMessage = "Tên tác giả là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Tên tác giả không được dài hơn 100 ký tự.")]
    public string AuthorName { get; set; }

    [Required(ErrorMessage = "Quốc tịch là bắt buộc.")]
    public string Nationality { get; set; }

    [Required(ErrorMessage = "Năm sinh là bắt buộc.")]
    [Range(1700, 2024, ErrorMessage = "Năm sinh phải nằm trong khoảng từ 1700 đến năm hiện tại.")]
    public int BirthYear { get; set; }

    // Tác giả có nhiều sách
    public ICollection<Book> Books { get; set; }
}
