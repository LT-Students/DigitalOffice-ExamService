using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbUserAnswerMapper : IDbUserAnswerMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbUserAnswerMapper(
      IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbUserAnswer Map(CreateUserAnswerRequest request)
    {
      return request is null
        ? null
        : new DbUserAnswer()
        {
          Id = Guid.NewGuid(),
          UserId = _httpContextAccessor.HttpContext.GetUserId(),
          QuestionId = request.QuestionId,
          AnswerId = request.AnswerId,
          Custom = request.Custom,
          CreatedAtUtc = DateTime.UtcNow,
          Question = null
        };
    }
  }
}
