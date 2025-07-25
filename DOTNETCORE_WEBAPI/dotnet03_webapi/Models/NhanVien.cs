using System.ComponentModel.DataAnnotations;

public class NhanVien
{
    [Key]
    public int IdNV { get; set; }
    public string tenNV { get; set; }
    public decimal luong { get; set; }
    public bool gioiTinh { get; set; }
    public int maPhongBan { get; set; }

    public PhongBan phongban { get; set; }
}