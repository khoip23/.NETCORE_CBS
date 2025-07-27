using System.ComponentModel.DataAnnotations;

public class NhanVienVM
{
    [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
    public string tenNV { get; set; }
    public decimal luong { get; set; }
    [Required(ErrorMessage = "Mã nhân viên không được bỏ trống")]
    [RegularExpression(@"^[1-3]$", ErrorMessage = "Gía trị phải là 1 hoặc 2 hoặc 3.")]
    public int maPhongBan { get; set; }
    public string moTa { get; set; }
    public int tuoi { get; set; }
    public bool gioiTinh { get; set; }
}