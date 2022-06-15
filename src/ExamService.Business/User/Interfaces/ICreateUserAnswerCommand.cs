using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User.Interfaces
{
  [AutoInject]
  public interface ICreateUserAnswerCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(List<CreateUserAnswerRequest> request);
  }
}
