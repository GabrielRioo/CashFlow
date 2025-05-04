using CashFlow.Communication.Enum;

namespace CashFlow.Communication.Requests;

public class RequestExpenseJson
{
    public string  Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public EPaymentType PaymentType { get; set; }
}
