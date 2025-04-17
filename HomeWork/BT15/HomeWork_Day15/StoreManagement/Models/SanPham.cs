namespace ProductManagement.Models
{
    public abstract class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double GiaGoc { get; set; }

        // Phương thức trừu tượng để tính giá bán
        public abstract double TinhGiaBan();

        // Phương thức hiển thị thông tin
        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã: {MaSanPham}, Tên: {TenSanPham}, Giá gốc: {GiaGoc} VND");
        }
    }
}
