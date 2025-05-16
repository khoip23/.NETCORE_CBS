namespace ProductManagement.Models
{
    public class ThucPham : SanPham
    {
        public double PhiVanChuyen { get; set; }

        public override double TinhGiaBan()
        {
            return GiaGoc + PhiVanChuyen;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán: {TinhGiaBan()} VND (đã bao gồm phí vận chuyển)");
        }
    }
}
