namespace ProductManagement.Models
{
    public class ThoiTrang : SanPham
    {
        public double GiamGia { get; set; }

        public override double TinhGiaBan()
        {
            return GiaGoc - GiamGia;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán: {TinhGiaBan()} VND (sau khi áp dụng giảm giá)");
        }
    }
}
