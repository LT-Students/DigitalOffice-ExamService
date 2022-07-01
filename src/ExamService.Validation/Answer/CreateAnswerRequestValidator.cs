using FluentValidation;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.ExamService.Validation.Answer.Interfaces;

namespace LT.DigitalOffice.ExamService.Validation.Answer
{
  public class CreateAnswerRequestValidator : AbstractValidator<CreateAnswerRequest>, ICreateAnswerRequestValidator
  {
    public CreateAnswerRequestValidator()
    {
      RuleFor(request => request.Answer)
        .Cascade(CascadeMode.Stop)
        .MinimumLength(0).WithMessage("Minimum length is 0")
        .MaximumLength(500).WithMessage("Maximum length mustn't be greater than 500");
    }
  }
}