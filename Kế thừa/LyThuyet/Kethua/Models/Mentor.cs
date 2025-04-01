public class Mentor
{
    public string HoTen { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }


    public void DangNhap()
    {
        Console.WriteLine("Đăng nhập thành công!");
    }
    public void DangXuat()
    {
        Console.WriteLine("Đăng xuất thành công!");
    }
    public void ChamBai()
    {
        Console.WriteLine("Chấm bài tập thành công!");
    }
}