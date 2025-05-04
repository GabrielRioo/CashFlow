using CashFlow.Communication.Requests;

namespace CashFlow.Aplication.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
