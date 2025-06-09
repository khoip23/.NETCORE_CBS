using System.ComponentModel.DataAnnotations;

namespace HomeWork_Day28.ViewModels
{
    public class WalletVM
    {
        public string? Type { get; set; } // Loại giao dịch
        [Required]
        public double Amount { get; set; } // Số tiền
        public DateTime Date { get; set; } // Ngày giao dịch
        public double Balance { get; set; } = 2234.21; // Số dư mặc định
    }


}
