using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class UserQuestionInfoMapper
  {
    private readonly IAnswerInfoMapper _answerMapper;
    private readonly IUserAnswerInfoMapper _userAnswerMapper;

    public UserQuestionInfoMapper(
      IAnswerInfoMapper answerMapper,
      IUserAnswerInfoMapper userAnswerMapper)
    {
      _answerMapper = answerMapper;
      _userAnswerMapper = userAnswerMapper;
    }

    public UserQuestionInfo Map(DbQuestion dbQuestion, bool showRightAnswers = false)
    {
      return dbQuestion is null
        ? null
        : new UserQuestionInfo()
        {
          Id = dbQuestion.Id,
          Subject = dbQuestion.Subject,
          Score = dbQuestion.Score,
          Answers = showRightAnswers
            ? dbQuestion.Answers.Select(_answerMapper.FuillInfoMap).ToList()
            : dbQuestion.Answers.Select(_answerMapper.Map).ToList(),
          UserAnswer = _userAnswerMapper.Map(dbQuestion.UsersAnswers?.FirstOrDefault())
        };
    }
  }
}
