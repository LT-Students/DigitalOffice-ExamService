using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;

namespace LT.DigitalOffice.ExamService.Mappers.Patch.Interfaces
{
  [AutoInject]
  public interface IPatchDbAnswerMapper
  {
    JsonPatchDocument<DbAnswer> Map(JsonPatchDocument<EditAnswerRequest> request);
  }
}