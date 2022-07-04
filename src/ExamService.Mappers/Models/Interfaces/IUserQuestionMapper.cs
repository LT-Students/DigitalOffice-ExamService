using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;

namespace LT.DigitalOffice.ExamService.Mappers.Models.Interfaces
{
  public interface IUserQuestionMapper
  {
    UserQuestionInfo Map(DbQuestion dbQuestion, bool showRightAnswers = false);
  }
}
