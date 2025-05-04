using CashFlow.Communication.Responses;

namespace CashFlow.Aplication.UseCases.Expenses.GetById;

public interface IGetExpenseByIdUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}
