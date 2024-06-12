using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionApi.Models
{
    public class Transaction 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "O valor da transação é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da transação deve ser maior que zero.")]
        public decimal Amount { get; set; }
        
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
        [EnumDataType(typeof(TransactionType), ErrorMessage = "Tipo de transação inválido.")]
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Addition,
        Subtraction
    }
}
