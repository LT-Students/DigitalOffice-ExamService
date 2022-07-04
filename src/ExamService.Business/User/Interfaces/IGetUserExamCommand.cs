using LT.DigitalOffice.ExamService.Models.Dto.Response.User;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User.Interfaces
{
  [AutoInject]
  public interface IGetUserExamCommand
  {
    Task<OperationResultResponse<UserExamResponse>> ExecuteAsync(Guid examId);
  }
}
