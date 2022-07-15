using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.JsonPatch.Operations;
using LT.DigitalOffice.Kernel.Validators;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.ExamService.Validation.Answer.Interfaces;

namespace LT.DigitalOffice.ExamService.Validation.Answer
{
  public class EditAnswerRequestValidator : BaseEditRequestValidator<EditAnswerRequest>, IEditAnswerRequestValidator
  {
    private void HandleInternalPropertyValidation(
      Operation<EditAnswerRequest> requestedOperation,
      CustomContext context)
    {
      Context = context;
      RequestedOperation = requestedOperation;

      #region paths

      AddСorrectPaths(
        new() { nameof(EditAnswerRequest.Option), nameof(EditAnswerRequest.IsCorrect), });

      AddСorrectOperations(nameof(EditAnswerRequest.Option), new() { OperationType.Replace });
      AddСorrectOperations(nameof(EditAnswerRequest.IsCorrect), new() { OperationType.Replace });

      #endregion

      #region Option

      AddFailureForPropertyIf(nameof(EditAnswerRequest.Option),
        operationType => operationType == OperationType.Replace,
        new() {
          { request => !string.IsNullOrEmpty(request.value?.ToString()), "Option can't be be empty." },
          { request => request.value?.ToString().Length < 500, "Option's name is too long" }
        },
        CascadeMode.Stop);

      #endregion

      #region IsActive

      AddFailureForPropertyIf(
        nameof(EditAnswerRequest.IsCorrect),
        operationType => operationType == OperationType.Replace,
        new() 
        {
          { request => bool.TryParse(request.value?.ToString(), out _), "Incorrect IsCorrect value." }
        });

      #endregion
    }

    public EditAnswerRequestValidator()
    {
      RuleForEach(request => request.Operations)
        .Custom(HandleInternalPropertyValidation);
    }
  }
}