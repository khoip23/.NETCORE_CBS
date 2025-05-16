using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Services
{
    public class ProductService
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();

        public void ThemSanPham(SanPham sanPham)
        {
            danhSachSanPham.Add(sanPham);
            Console.WriteLine("Thêm sản phẩm thành công!");
        }

        public void HienThiDanhSachSanPham()
        {
            if (danhSachSanPham.Count == 0)
            {
                Console.WriteLine("Danh sách sản phẩm trống.");
                return;
            }

            foreach (var sanPham in danhSachSanPham)
            {
                sanPham.HienThiThongTin();
            }
        }

        public double TinhTongDoanhThu()
        {
            double tong = 0;
            foreach (var sanPham in danhSachSanPham)
            {
                tong += sanPham.TinhGiaBan();
            }
            return tong;
        }

        public void XoaSanPham(string maSanPham)
        {
            var sanPham = danhSachSanPham.Find(sp => sp.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                danhSachSanPham.Remove(sanPham);
                Console.WriteLine("Xóa sản phẩm thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm với mã này.");
            }
        }
    }
}
