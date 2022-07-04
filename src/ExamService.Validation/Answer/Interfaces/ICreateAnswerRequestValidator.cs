using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;

namespace LT.DigitalOffice.ExamService.Validation.Answer.Interfaces
{
  [AutoInject]
  public interface ICreateAnswerRequestValidator : IValidator<CreateAnswerRequest>
  {
  }
}