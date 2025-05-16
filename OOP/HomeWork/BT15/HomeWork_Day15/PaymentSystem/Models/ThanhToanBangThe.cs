using PaymentSystem.Interfaces;

namespace PaymentSystem.Models
{
    public class ThanhToanBangThe : IThanhToan
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.Write("Nhập mã PIN: ");
            var pin = Console.ReadLine();
            if (pin == "1234") // Ví dụ mã PIN
            {
                Console.WriteLine($"Thanh toán bằng thẻ: {soTien} VND");
                return true;
            }
            Console.WriteLine("Mã PIN không hợp lệ.");
            return false;
        }
    }
}
