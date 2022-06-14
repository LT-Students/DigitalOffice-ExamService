using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class QuestionInfoMapper : IQuestionInfoMapper
  {
    private readonly IAnswerInfoMapper _answerMapper;

    public QuestionInfoMapper(
      IAnswerInfoMapper answerMapper)
    {
      _answerMapper = answerMapper;
    }

    public QuestionInfo Map(DbQuestion dbQuestion)
    {
      return dbQuestion is null
        ? null
        : new QuestionInfo()
        {
          Id = dbQuestion.Id,
          ExamId = dbQuestion.ExamId,
          Subject = dbQuestion.Subject,
          Score = dbQuestion.Score,
          Answers = dbQuestion.Answers.Select(_answerMapper.Map).ToList()
        };
    }
  }
}
