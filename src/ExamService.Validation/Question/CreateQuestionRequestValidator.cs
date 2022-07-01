using FluentValidation;
using LT.DigitalOffice.ExamService.Validation.Question.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;
using LT.DigitalOffice.ExamService.Validation.Answer.Interfaces;

namespace LT.DigitalOffice.ExamService.Validation.Question
{
  public class CreateQuestionRequestValidator : AbstractValidator<CreateQuestionRequest>, ICreateQuestionRequestValidator
  {
    public CreateQuestionRequestValidator(ICreateAnswerRequestValidator answerValidator)
    {
      RuleFor(request => request.Subject)
        .Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Subject mustn't be empty")
        .MinimumLength(3).WithMessage("Minimum length must be greater than 3")
        .MaximumLength(500).WithMessage("Maximum length mustn't be greater than 500");

      RuleFor(request => request.Answers)
        .ForEach(answer =>
        {
          answer
            .SetValidator(answerValidator);
        });
    }
  }
}