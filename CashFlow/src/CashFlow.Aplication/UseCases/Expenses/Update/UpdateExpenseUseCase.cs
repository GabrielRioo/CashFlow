
using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Aplication.UseCases.Expenses.Update;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IExpensesUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseUseCase(IExpensesUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetById(id);

        if (expense is null) 
        {
            throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
        }
        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestExpenseJson request) 
    {
        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid is false) 
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
