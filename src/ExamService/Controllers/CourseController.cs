using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Course;
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

    [HttpGet("find")]
    public async Task<FindResultResponse<CourseInfo>> FindAsync(
      [FromServices] IFindCourseCommand command,
      [FromQuery] FindCourseFilter filter)
    {
      return await command.ExecuteAsync(filter);
    }

    [HttpGet("get")]
    public async Task<OperationResultResponse<CourseResponse>> GetAsync(
      [FromServices] IGetCourseCommand command,
      [FromQuery] Guid courseId)
    {
      return await command.ExecuteAsync(courseId);
    }
  }
}
