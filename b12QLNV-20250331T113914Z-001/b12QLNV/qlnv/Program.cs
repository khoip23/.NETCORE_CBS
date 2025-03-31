public class Program
{
    static void Main()
    {
        // khởi tạo đối tượn quản lý nhân viên
        QuanLyNhanVien qly = new QuanLyNhanVien(); // dùng contructor default của c#
        while (true)
        {
            qly.ShowChucNang();
            qly.ChonChucNang();
            switch (qly.Chon)
            {
                case 1:
                    qly.ThemNV();
                    break;
                case 2:
                    Console.Write("Ban muốn tìm ai: ");
                    string ten = Console.ReadLine();
                    qly.TimKiem(ten);
                    break;
                case 3:
                    qly.HienThiDanhSach();

                    Console.Write("Chọn mã người dùng cần đổi tên: ");
                    int i = int.Parse(Console.ReadLine());
                    Console.Write("Nhập vào tên mới: ");
                    string newName = Console.ReadLine();
                    qly.DoiTen(i, newName);
                    break;
                case 4:
                    qly.HienThiDanhSach();
                    Console.Write("Nhập vào id cần xoá: ");
                    int input = int.Parse(Console.ReadLine());
                    qly.XoaNV(input);
                    break;
                case 5:
                    Console.WriteLine("DANH SÁCH NHÂN VIÊN");
                    qly.HienThiDanhSach();
                    break;
                case 6:
                    Console.WriteLine("Tạm biệt !!");
                    return;
                case 7:
                    qly.luuData();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
