using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CourseController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateCourseCommand command,
      [FromBody] CreateCourseRequest request)
    {
      return await command.ExecuteAsync(request);
    }
  }
}
