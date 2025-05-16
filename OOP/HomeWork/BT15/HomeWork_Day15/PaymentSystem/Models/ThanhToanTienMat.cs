using PaymentSystem.Interfaces;

namespace PaymentSystem.Models
{
    public class ThanhToanTienMat : IThanhToan
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.WriteLine($"Thanh toán bằng tiền mặt: {soTien} VND");
            return true;
        }
    }
}
