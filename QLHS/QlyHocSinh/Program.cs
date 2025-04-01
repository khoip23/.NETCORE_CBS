public class Program
{
    static void Main()
    {
        // khởi tạo đối tượn quản lý nhân viên
        QuanLyHocSinh qly = new QuanLyHocSinh(); // dùng contructor default của c#
        while (true)
        {
            qly.ShowChucNang();
            qly.ChonChucNang();
            switch (qly.Chon)
            {
                case 1:
                    qly.ThemHS();
                    break;
                case 2:
                    qly.HienThiDanhSach();
                    Console.Write("Nhập vào id cần xoá: ");
                    int input = int.Parse(Console.ReadLine());
                    qly.XoaHS(input);
                    break;
                case 3:
                    qly.HienThiDanhSach();
                    break;
                case 4:
                    qly.luuData();
                    break;
                case 5:
                    Console.WriteLine("Tạm biệt !!");
                    return;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
