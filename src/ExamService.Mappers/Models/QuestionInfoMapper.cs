using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class QuestionInfoMapper : IQuestionInfoMapper
  {
    private readonly IAnswerInfoMapper _answerMapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public QuestionInfoMapper(
      IAnswerInfoMapper answerMapper,
      IHttpContextAccessor httpContextAccessor)
    {
      _answerMapper = answerMapper;
      _httpContextAccessor = httpContextAccessor;
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
          Answers = _httpContextAccessor.HttpContext.GetUserId() == dbQuestion.CreatedBy
          ? dbQuestion.Answers.Select(_answerMapper.FuillInfoMap).ToList()
          : dbQuestion.Answers.Select(_answerMapper.Map).ToList()
        };
    }
  }
}
