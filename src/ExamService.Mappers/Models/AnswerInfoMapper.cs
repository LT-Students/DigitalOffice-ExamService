using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class AnswerInfoMapper : IAnswerInfoMapper
  {
    public AnswerInfo Map(DbAnswer dbAnswer)
    {
      return dbAnswer is null
        ? null
        : new AnswerInfo
        {
          Id = dbAnswer.Id,
          QuestionId = dbAnswer.QuestionId,
          Answer = dbAnswer.Option,
          IsCorrect = null
        };
    }

    public AnswerInfo FuillInfoMap(DbAnswer dbAnswer)
    {
      return dbAnswer is null
        ? null
        : new AnswerInfo
        {
          Id = dbAnswer.Id,
          QuestionId = dbAnswer.QuestionId,
          Answer = dbAnswer.Option,
          IsCorrect = dbAnswer.IsCorrect
        };
    }
  }
}
