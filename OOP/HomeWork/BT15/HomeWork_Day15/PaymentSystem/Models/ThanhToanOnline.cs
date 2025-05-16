using PaymentSystem.Interfaces;

namespace PaymentSystem.Models
{
    public class ThanhToanOnline : IThanhToan
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.Write("Nhập mã OTP: ");
            var otp = Console.ReadLine();
            if (otp == "9999") // Ví dụ OTP
            {
                Console.WriteLine($"Thanh toán online: {soTien} VND");
                return true;
            }
            Console.WriteLine("Mã OTP không hợp lệ.");
            return false;
        }
    }
}
