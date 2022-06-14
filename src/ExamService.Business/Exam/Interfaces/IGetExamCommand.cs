using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam.Interfaces
{
  [AutoInject]
  public interface IGetExamCommand
  {
    Task<OperationResultResponse<ExamResponse>> ExecuteAsync(Guid examId);
  }
}
