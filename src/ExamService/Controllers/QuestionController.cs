using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.ExamService.Business.Question.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;

namespace LT.DigitalOffice.ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class QuestionController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromBody] CreateQuestionRequest request,
      [FromServices] ICreateQuestionCommand command)
    {
      return await command.ExecuteAsync(request);
    }
  }
}