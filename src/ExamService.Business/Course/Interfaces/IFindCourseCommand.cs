using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Course.Interfaces
{
  [AutoInject]
  public interface IFindCourseCommand
  {
    Task<FindResultResponse<CourseInfo>> ExecuteAsync(FindCourseFilter filter);
  }
}
