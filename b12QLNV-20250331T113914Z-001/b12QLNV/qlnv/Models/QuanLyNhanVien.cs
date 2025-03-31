using System.Text.Json;
using System.Text.Json.Serialization;
using Unidecode.NET;

class QuanLyNhanVien
{
    // thuộc tính
    // cần có 1 danh sách để quản lý
    List<NhanVien>? ds = new List<NhanVien>(); // khởi tạo list rỗng

    //[{new NhanVien(), new NhanVien(),..........}]

    public QuanLyNhanVien()
    {
        docData(); // đọc dữ liệu từ file
    }

    public int Chon { get; set; }

    //phương thức
    // Thêm nhân viên
    public void ThemNV()
    {
        Console.Write("Nhập tên NV: ");
        string ten = Console.ReadLine();
        Console.Write("Lương làm việc 1h: ");
        double luong = double.Parse(Console.ReadLine());
        Console.Write("Số giờ làm việc: ");
        double soGio = double.Parse(Console.ReadLine());
        NhanVien emp = new NhanVien(ten, luong, soGio);
        // NhanVien emp = new NhanVien(luong,ten,soGio);
        ds.Add(emp);
        Console.WriteLine("Đã thêm thành công!");
    }

    // Tìm kiếm  nhận vào tên
    public void TimKiem(string ten)
    {
        // "   Nga   "
        // xử lý tìm kiếm không dấu
        // string a = "tiếng việt";
        // a.Unidecode();// tieng viet
        // nhã -> nha
        // Vương , Nhàn, Nhã, Nhạn, Nhân, ....
        // nv đối tượng có các thuộc tính
        var res = ds.Where(nv =>
            nv.TenNV.Trim().Unidecode().ToLower().Contains(ten.Trim().Unidecode().ToLower())
        );
        // nv.TenNV.Unidecode().ToLower(): chuyển tên trong ds thành tiết việt ghi thường không dâu
        //ten.Unidecode().ToLower(): tên người dùng muốn tìm thành nt
        // Constain
        // show kết quả
        Console.WriteLine("Kết quả tìm kiếm");
        foreach (var a in res)
        {
            a.ShowInfor();
        }
    }

    // Đổi tên
    // muốn đổi tên ai , và đổi thành cái gì
    public void DoiTen(int id, string newName)
    {
        int nvFind = ds.FindIndex(a => a.MaNV == id); // vị trí đầu tiên thoả DK
        ds[nvFind].TenNV = newName; // là giá trị tham chiếu
        Console.WriteLine("Đã đổi tên");
    }

    //Xoá nhân viên
    public void XoaNV(int id)
    { // nhận tham số qua trung gian(Nhận từ FE)
        // tìm xem có nhân viên tương ứng với id này hay không
        int nvFind = ds.FindIndex(a => a.MaNV == id); // vị trí đầu tiên thoả DK
        if (nvFind != -1)
        { // có thì xoá
            ds.RemoveAt(nvFind);
            Console.WriteLine($"Đã xoá thành công nhân viên có mã là {id}");
        }
        else
        {
            Console.WriteLine($"Không tìm thấy nhân viên có mã là {id}");
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
        2/ Tìm kiếm thông tin nhân viên dựa vào tên nhân viên (tên nhân viên không dấu)
        3/ Thay đổi tên nhân viên (khó)
        4/ Xoá nhân viên
        5/ Hiển thị danh sách thông tin nhân viên bao gồm: (mã nhân viên, tên nhân viên, lương dựa trên số giờ làm)
        6/ Thoát
        ";
        Console.WriteLine(lsmenu);
    }

    // danh sách chức năng
    // kêu người dùng chọn chức năng từ 1 đến 6
    public void ChonChucNang()
    {
        Console.Write("Hãy chọn chức năng từ 1 -> 6: ");
        int n = int.Parse(Console.ReadLine());
        Chon = n;
    }

    // cần lưu lại list vào file json để khi start lại vẫn có dữ liệu
    //khi chạy vẫn còn data cũ
    //phương thức lưu data

    public void luuData()
    {
        // chuyển đổi đối tượng thành chuỗi json
        // JsonSerializer.Serialize(ds);
        string jsonString = JsonSerializer.Serialize(ds);
        // lưu vào file
        File.WriteAllText("data.json", jsonString);
        System.Console.WriteLine("Đã lưu dữ liệu vào file data.json");
    }

    //đọc dữ liệu từ file
    public void docData()
    {
        // đọc file
        string jsonString = File.ReadAllText("./data.json");
        // chuyển đổi chuỗi json thành đối tượng
        ds = JsonSerializer.Deserialize<List<NhanVien>>(jsonString);
        System.Console.WriteLine("Đã đọc dữ liệu từ file data.json");

        // update lại id đếm để không bị trùng mã nhân viên

        // Lấy ra nhân viên cuối cùng trong danh sách
        var lastEmp = ds?.LastOrDefault();
        if (lastEmp == null)
        {
            NhanVien.IdDem = 1; // Nếu danh sách rỗng, bắt đầu từ 1
            return;
        }
        NhanVien.IdDem = lastEmp.MaNV++; // mã nhân viên cuối cùng +1
    }
}
