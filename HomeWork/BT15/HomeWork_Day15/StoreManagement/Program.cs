using ProductManagement.Models;
using ProductManagement.Services;
using System;

namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();

            while (true)
            {
                Console.WriteLine("---- Hệ thống quản lý bán hàng ----");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Tính tổng doanh thu");
                Console.WriteLine("4. Xóa sản phẩm");
                Console.WriteLine("5. Thoát");
                Console.Write("Vui lòng chọn chức năng: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Loại sản phẩm:");
                        Console.WriteLine("1. Điện tử");
                        Console.WriteLine("2. Thời trang");
                        Console.WriteLine("3. Thực phẩm");
                        Console.Write("Lựa chọn: ");
                        var loai = Console.ReadLine();

                        Console.Write("Nhập mã sản phẩm: ");
                        var ma = Console.ReadLine();
                        Console.Write("Nhập tên sản phẩm: ");
                        var ten = Console.ReadLine();
                        Console.Write("Nhập giá gốc: ");
                        if (!double.TryParse(Console.ReadLine(), out var giaGoc))
                        {
                            Console.WriteLine("Giá không hợp lệ.");
                            continue;
                        }

                        if (loai == "1")
                        {
                            Console.Write("Nhập thuế bảo hành: ");
                            var thue = double.Parse(Console.ReadLine());
                            var dienTu = new DienTu { MaSanPham = ma, TenSanPham = ten, GiaGoc = giaGoc, ThueBaoHanh = thue };
                            productService.ThemSanPham(dienTu);
                        }
                        else if (loai == "2")
                        {
                            Console.Write("Nhập giảm giá: ");
                            var giamGia = double.Parse(Console.ReadLine());
                            var thoiTrang = new ThoiTrang { MaSanPham = ma, TenSanPham = ten, GiaGoc = giaGoc, GiamGia = giamGia };
                            productService.ThemSanPham(thoiTrang);
                        }
                        else if (loai == "3")
                        {
                            Console.Write("Nhập phí vận chuyển: ");
                            var phiVanChuyen = double.Parse(Console.ReadLine());
                            var thucPham = new ThucPham { MaSanPham = ma, TenSanPham = ten, GiaGoc = giaGoc, PhiVanChuyen = phiVanChuyen };
                            productService.ThemSanPham(thucPham);
                        }
                        else
                        {
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                        }
                        break;

                    case "2":
                        productService.HienThiDanhSachSanPham();
                        break;

                    case "3":
                        Console.WriteLine($"Tổng doanh thu dự kiến: {productService.TinhTongDoanhThu()} VND");
                        break;

                    case "4":
                        Console.Write("Nhập mã sản phẩm cần xóa: ");
                        var maCanXoa = Console.ReadLine();
                        productService.XoaSanPham(maCanXoa);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
