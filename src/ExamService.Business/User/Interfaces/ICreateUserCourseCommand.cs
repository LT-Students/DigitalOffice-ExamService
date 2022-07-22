using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User.Interfaces
{
  [AutoInject]
  public interface ICreateUserCourseCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(Guid courseId, Guid userId);
  }
}
