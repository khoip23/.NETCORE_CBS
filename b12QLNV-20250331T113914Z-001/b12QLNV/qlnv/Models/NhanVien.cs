using System.Text.Json.Serialization;

class NhanVien
{
    public static int IdDem = 1;

    //Thuộc tính
    public int MaNV { get; set; } // tự tăng , không cần nhập
    public string TenNV { get; set; }
    public double Luong1h { get; set; }
    public double SoGioLam { get; set; }

    public NhanVien()
    {
        // contructor mặc định
    }

    //Hàm tạo  kèm theo xử lý tự động tăng Id
    public NhanVien(string ten, double luong1h, double SoGioLam)
    {
        MaNV = IdDem++; // iddem default =1
        TenNV = ten;
        Luong1h = luong1h;
        this.SoGioLam = SoGioLam; // nếu tham số có tên giống với thuộc tính thì cần dùng từ khoa this để xác định đâu là giá trị của đối đượng NhanVienß
    }

    //phương thức

    //tính tổng lương
    public double TinhLuong()
    {
        return Luong1h * SoGioLam;
    }

    // hiện thị thong tin cá nhân
    public void ShowInfor()
    {
        Console.WriteLine($"{MaNV} - {TenNV} - Lương: {TinhLuong()}");
    }
}
