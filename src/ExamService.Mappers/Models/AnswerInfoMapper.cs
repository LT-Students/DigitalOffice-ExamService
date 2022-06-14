using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
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
          Option = dbAnswer.Option
        };
    }
  }
}
