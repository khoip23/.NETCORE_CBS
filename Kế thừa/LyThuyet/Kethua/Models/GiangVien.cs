public class GiangVien
{
    public string HoTen { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }
    public string HeSoLuong { get; set; }

    public void DangNhap()
    {
        Console.WriteLine("Đăng nhập thành công!");
    }
    public void DangXuat()
    {
        Console.WriteLine("Đăng xuất thành công!");
    }
    public void giaHan()
    {
        Console.WriteLine("Gia hạn bài tập thành công!");
    }
}