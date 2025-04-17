namespace ProductManagement.Models
{
    public class DienTu : SanPham
    {
        public double ThueBaoHanh { get; set; }

        public override double TinhGiaBan()
        {
            return GiaGoc + ThueBaoHanh;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán: {TinhGiaBan()} VND (đã bao gồm thuế bảo hành)");
        }
    }
}
