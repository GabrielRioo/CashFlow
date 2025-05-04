using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Aplication.UseCases.Expenses.Register;
public interface IRegisterExpensesUseCase
{
    Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson response);
}
