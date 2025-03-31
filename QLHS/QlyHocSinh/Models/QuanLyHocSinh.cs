using System.Text.Json;
using System.Text.Json.Serialization;
// using Unidecode.NET;

class QuanLyHocSinh
{
    // thuộc tính
    // cần có 1 danh sách để quản lý
    List<HocSinh> ds = new List<HocSinh>(); // khởi tạo list rỗng

    public int Chon { get; set; }

    //phương thức
    // Thêm học sinh
    public void ThemHS()
    {
        Console.Write("Nhập tên HS: ");
        string ten = Console.ReadLine();
        Console.Write("Nhập điểm toán: ");
        int diemToan = int.Parse(Console.ReadLine());
        Console.Write("Nhập điểm văn: ");
        int diemVan = int.Parse(Console.ReadLine());
        Console.Write("Nhập điểm anh: ");
        int diemAnh = int.Parse(Console.ReadLine());
        HocSinh emp = new HocSinh(ten, diemToan, diemVan, diemAnh); // khởi tạo đối tượng
        ds.Add(emp);
        Console.WriteLine("Đã thêm thành công!");
    }

    //Xoá nhân viên
    public void XoaHS(int id)
    { // nhận tham số qua trung gian(Nhận từ FE)
        // tìm xem có học sinh tương ứng với id này hay không
        int hsFind = ds.FindIndex(a => a.Id == id); // vị trí đầu tiên thoả DK
        if (hsFind != -1)
        { // có thì xoá
            ds.RemoveAt(hsFind);
            Console.WriteLine($"Đã xoá thành công học sinh có mã là {hsFind}");
        }
        else
        {
            Console.WriteLine($"Không tìm thấy học sinh có mã là {hsFind}");
        }
    }

    // Hiển thị danh sách
    public void HienThiDanhSach()
    {
        // hiển thị danh sách nhâ viên
        foreach (var nv in ds)
        {
            nv.ShowInfor();
        }
    }

    //Chon chuc năng

    public void ShowChucNang()
    {
        string lsmenu =
            @"
-------------Danh sách chức năng------------------
        1/ Thêm nhân viên
        2/ Xoá nhân viên
        3/ Thoát
        ";
        Console.WriteLine(lsmenu);
    }

    // danh sách chức năng
    // kêu người dùng chọn chức năng từ 1 đến 6
    public void ChonChucNang()
    {
        Console.Write("Hãy chọn chức năng từ 1 -> 3: ");
        int n = int.Parse(Console.ReadLine());
        Chon = n;
    }
}
