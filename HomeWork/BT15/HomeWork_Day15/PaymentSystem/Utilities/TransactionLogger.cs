using System.Text.Json;

namespace PaymentSystem.Utilities
{
    public class TransactionLogger
    {
        public void SaveTransaction(string filename, string transactionDetails)
        {
            File.AppendAllText(filename, transactionDetails + Environment.NewLine);
        }

        public void ViewTransactionHistory(string filename)
        {
            if (File.Exists(filename))
            {
                var content = File.ReadAllText(filename);
                Console.WriteLine("Lịch sử giao dịch:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Không có lịch sử giao dịch.");
            }
        }
    }
}
