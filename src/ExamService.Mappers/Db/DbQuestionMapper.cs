using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbQuestionMapper : IDbQuestionMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDbAnswerMapper _dbAnswerMapper;

    public DbQuestionMapper(
      IHttpContextAccessor httpContextAccessor,
      IDbAnswerMapper dbAnswerMapper)
    {
      _httpContextAccessor = httpContextAccessor;
      _dbAnswerMapper = dbAnswerMapper;
    }

    public DbQuestion Map(CreateQuestionRequest request, Guid examId)
    {
      Guid questionId = Guid.NewGuid();

      return request is null
        ? null
        : new DbQuestion()
        {
          Id = questionId,
          ExamId = examId,
          Subject = request.Subject,
          Score = request.Score,
          CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
          CreatedAtUtc = DateTime.UtcNow,
          Answers = request.Answers?.Select(a => _dbAnswerMapper.Map(a, questionId)).ToList()
        };
    }
  }
}
