using CashFlow.Communication.Enum;

namespace CashFlow.Communication.Responses;

public class ResponseExpenseJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public EPaymentType PaymentType { get; set; }
}
