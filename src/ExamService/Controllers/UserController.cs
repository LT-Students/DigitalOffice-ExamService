using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<bool>> CreateAsync(
      [FromServices] ICreateUserAnswerCommand command,
      [FromBody] List<CreateUserAnswerRequest> request)
    {
      return await command.ExecuteAsync(request);
    }
  }
}
