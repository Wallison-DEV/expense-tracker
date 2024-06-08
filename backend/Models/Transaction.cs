using System;


namespace TransactionApi.Models;
public class Transaction 
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public TransactionType Type { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}

public enum TransactionType
{
    Income,
    Expense
}

public class Employee 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}
