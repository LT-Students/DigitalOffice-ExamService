using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExamController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateExamCommand command,
      [FromBody] CreateExamRequest request)
    {
      return await command.ExecuteAsync(request);
    }

    [HttpGet("get")]
    public async Task<OperationResultResponse<ExamResponse>> GetAsync(
      [FromServices] IGetExamCommand command,
      [FromQuery] Guid examId)
    {
      return await command.ExecuteAsync(examId);
    }

    [HttpGet("find")]
    public async Task<FindResultResponse<ExamInfo>> FindAsync(
      [FromServices] IFindExamCommand command,
      [FromQuery] FindExamsFilter filter)
    {
      return await command.ExecuteAsync(filter);
    }
  }
}
