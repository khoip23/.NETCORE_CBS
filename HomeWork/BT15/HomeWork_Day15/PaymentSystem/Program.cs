using PaymentSystem.Interfaces;
using PaymentSystem.Models;
using PaymentSystem.Services;
using PaymentSystem.Utilities;

namespace PaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var paymentService = new PaymentService();
            var logger = new TransactionLogger();
            const string logFile = "transactions.json";

            while (true)
            {
                Console.WriteLine("Chào mừng đến với hệ thống thanh toán!");
                Console.WriteLine("1. Thanh toán bằng tiền mặt");
                Console.WriteLine("2. Thanh toán bằng thẻ");
                Console.WriteLine("3. Thanh toán online");
                Console.WriteLine("4. Xem lịch sử giao dịch");
                Console.WriteLine("5. Thoát");
                Console.Write("Vui lòng chọn chức năng: ");
                var choice = Console.ReadLine();

                if (choice == "5") break;

                  if (choice == "4")
                {
                    logger.ViewTransactionHistory(logFile);
                    continue;
                }

                Console.Write("Nhập số tiền cần thanh toán: ");
                if (!decimal.TryParse(Console.ReadLine(), out var amount))
                {
                    Console.WriteLine("Số tiền không hợp lệ.");
                    continue;
                }

                IThanhToan? paymentMethod = choice switch
                {
                    "1" => new ThanhToanTienMat(),
                    "2" => new ThanhToanBangThe(),
                    "3" => new ThanhToanOnline(),
                    _ => null
                };

                if (paymentMethod == null)
                {
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    continue;
                }

                string methodDescription = choice switch
                {
                    "1" => "Thanh toán tiền mặt",
                    "2" => "Thanh toán thẻ",
                    "3" => "Thanh toán online",
                    _ => "Unknown"
                };

                paymentService.ProcessPayment(paymentMethod, amount);
                logger.SaveTransaction(logFile, $"Method: {methodDescription}, Amount: {amount}");
            }
        }
    }
}
