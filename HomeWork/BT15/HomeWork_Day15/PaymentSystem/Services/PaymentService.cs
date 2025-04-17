using PaymentSystem.Interfaces;

namespace PaymentSystem.Services
{
    public class PaymentService
    {
        public void ProcessPayment(IThanhToan paymentMethod, decimal amount)
        {
            if (paymentMethod.ThanhToan(amount))
            {
                Console.WriteLine("Thanh toán thành công!");
            }
            else
            {
                Console.WriteLine("Thanh toán thất bại!");
            }
        }
    }
}
