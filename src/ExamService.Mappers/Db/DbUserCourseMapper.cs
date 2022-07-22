using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbUserCourseMapper : IDbUserCourseMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbUserCourseMapper(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbUserCourse Map(Guid courseId, Guid userId)
    {
      return new()
      {
        Id = Guid.NewGuid(),
        CourseId = courseId,
        UserId = userId,
        IsActive = true,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        Course = null
      };
    }
  }
}
