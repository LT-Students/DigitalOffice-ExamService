using LT.DigitalOffice.ExamService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam.Interfaces
{
  public interface ICreateExamCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateExamRequest request);
  }
}
