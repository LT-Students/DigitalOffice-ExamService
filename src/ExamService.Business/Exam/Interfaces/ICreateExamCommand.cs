using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam.Interfaces
{
  [AutoInject]
  public interface ICreateExamCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateExamRequest request);
  }
}
