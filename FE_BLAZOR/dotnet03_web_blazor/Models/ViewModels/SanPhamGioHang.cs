public class SanPhamGioHang
{
    public int maSanPham { get; set; }
    public string? tenSanPham { get; set; }
    public double giaBan { get; set; }
    public double soLuong { get; set; }
    public string? hinhAnh { get; set; }

    public string tinhTongTien()
    {
        return (soLuong * giaBan).ToString("N0");
    }
}
