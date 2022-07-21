using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.ExamService.Mappers.Patch.Interfaces;

namespace LT.DigitalOffice.ExamService.Mappers.Patch.Answer
{
  public class PatchDbAnswerMapper : IPatchDbAnswerMapper
  {
    public JsonPatchDocument<DbAnswer> Map(JsonPatchDocument<EditAnswerRequest> request)
    {
      if (request is null)
      {
        return null;
      }

      JsonPatchDocument<DbAnswer> patchDbAnswer = new();

      foreach (Operation<EditAnswerRequest> item in request.Operations)
      {
        patchDbAnswer.Operations.Add(new Operation<DbAnswer>(item.op, item.path, item.from, item.value));
      }

      return patchDbAnswer;
    }
  }
}