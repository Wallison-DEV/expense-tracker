using System.ComponentModel.DataAnnotations;
using TransactionApi.Models;

namespace TransactionApi.Dtos
{
    public class TransactionCreateDto
    {
        [Required(ErrorMessage = "O valor da transação é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da transação deve ser maior que zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
        public TransactionType Type { get; set; }

        public string? Description { get; set; }
    }
}