using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Aplication.UseCases.Expenses.Register;
public interface IRegisterExpensesUseCase
{
    ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson response);
}
