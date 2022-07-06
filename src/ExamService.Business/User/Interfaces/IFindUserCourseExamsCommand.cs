using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User.Interfaces
{
  [AutoInject]
  public interface IFindUserCourseExamsCommand
  {
    Task<FindResultResponse<UserExamInfo>> ExecuteAsync(Guid courseId);
  }
}
