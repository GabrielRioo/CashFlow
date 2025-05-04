using CashFlow.Aplication.UseCases.Expenses;
using CashFlow.Communication.Enum;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange - Configurar as intancias
        var validator = new ExpenseValidator();

        var request = RequestRegisterExpenseJsonBuilder.Build();
        
        // Act - as a��es
        var result = validator.Validate(request);

        // Assert - resultado esperado
        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        // Arrange - Configurar as intancias
        var validator = new ExpenseValidator();

        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;

        // Act - as a��es
        var result = validator.Validate(request);

        // Assert - resultado esperado
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourcesErrorMessages.TITLE_REQUIRED);
    }

    [Fact]
    public void Error_Date_Future()
    {
        // Arrange - Configurar as intancias
        var validator = new ExpenseValidator();

        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act - as a��es
        var result = validator.Validate(request);

        // Assert - resultado esperado
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourcesErrorMessages.EXPENSES_CANNOT_BE_FOR_THE_FUTURE);
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        // Arrange - Configurar as intancias
        var validator = new ExpenseValidator();

        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (EPaymentType) 700;

        // Act - as a��es
        var result = validator.Validate(request);

        // Assert - resultado esperado
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourcesErrorMessages.PAYMENT_TYPE_INVALID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amout_Invalid(decimal amount)
    {
        // Arrange - Configurar as intancias
        var validator = new ExpenseValidator();

        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        // Act - as a��es
        var result = validator.Validate(request);

        // Assert - resultado esperado
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourcesErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
    }
}
