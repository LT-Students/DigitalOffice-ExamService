using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbAnswerMapper : IDbAnswerMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbAnswerMapper(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbAnswer Map(CreateAnswerRequest request, Guid questionId)
    {
      return request is null
        ? null
        : new DbAnswer()
        {
          Id = Guid.NewGuid(),
          QuestionId = questionId,
          Option = request.Answer,
          IsCorrect = request.IsCorrect,
          CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
          CreatedAtUtc = DateTime.UtcNow
        };
    }
  }
}
