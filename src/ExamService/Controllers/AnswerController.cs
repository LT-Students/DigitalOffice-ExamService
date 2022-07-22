using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.ExamService.Business.Answer.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;

namespace LT.DigitalOffice.ExamService.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AnswerController : ControllerBase
  {
    [HttpPatch("edit")]
    public async Task<OperationResultResponse<bool>> EditAsync(
      [FromServices] IEditAnswerCommand command,
      [FromQuery] Guid answerId, 
      [FromBody] JsonPatchDocument<EditAnswerRequest> request)
    {
      return await command.ExecuteAsync(answerId, request);
    }
  }
}