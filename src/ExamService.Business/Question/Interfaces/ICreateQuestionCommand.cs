using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;

namespace LT.DigitalOffice.ExamService.Business.Question.Interfaces
{
  [AutoInject]
  public interface ICreateQuestionCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateQuestionRequest request);
  }
}