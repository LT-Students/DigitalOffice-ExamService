using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserCourseController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<bool>> CreateAsync(
      [FromServices] ICreateUserCourseCommand command,
      [FromQuery] Guid courseId,
      [FromQuery] Guid userId)
    {
      return await command.ExecuteAsync(courseId, userId);
    }
  }
}
