using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class UserAnswerInfoMapper : IUserAnswerInfoMapper
  {
    public UserAnswerInfo Map(DbUserAnswer dbUserAnswer)
    {
      return dbUserAnswer is null
        ? null
        : new UserAnswerInfo()
        {
          AnswerId = dbUserAnswer.AnswerId,
          Custom = dbUserAnswer.Custom,
          CreatedAtUtc = dbUserAnswer.CreatedAtUtc
        };
    }
  }
}
