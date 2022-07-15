using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;

namespace LT.DigitalOffice.ExamService.Business.Answer.Interfaces
{
  [AutoInject]
  public interface IEditAnswerCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(Guid answerId, JsonPatchDocument<EditAnswerRequest> request);
  }
}