using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;

namespace LT.DigitalOffice.ExamService.Validation.Question.Interfaces
{
  [AutoInject]
  public interface ICreateQuestionRequestValidator : IValidator<CreateQuestionRequest>
  {
  }
}