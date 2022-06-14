using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam.Interfaces
{
  [AutoInject]
  public interface IFindExamCommand
  {
    Task<FindResultResponse<ExamInfo>> ExecuteAsync(FindExamsFilter filter);
  }
}
