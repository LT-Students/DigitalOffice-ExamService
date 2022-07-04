using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbExamMapper : IDbExamMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDbQuestionMapper _questionMapper;

    public DbExamMapper(
      IHttpContextAccessor httpContextAccessor,
      IDbQuestionMapper questionMapper)
    {
      _httpContextAccessor = httpContextAccessor;
      _questionMapper = questionMapper;
    }

    public DbExam Map(CreateExamRequest request)
    {
      Guid examId = Guid.NewGuid();

      return request is null
        ? null
        : new DbExam()
        {
          Id = examId,
          Name = request.Name,
          Description = request.Description,
          DeadLineUtc = request.DeadLineUtc,
          CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
          CreatedAtUtc = DateTime.UtcNow,
          Questions = request.Questions.Select(q => _questionMapper.Map(q, examId)).ToList()
        };
    }
  }
}
