using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbCourseMapper : IDbCourseMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbCourseMapper(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbCourse Map(CreateCourseRequest request)
    {
      return request is null
        ? null
        : new DbCourse()
        {
          Id = Guid.NewGuid(),
          ParentId = request.ParentId,
          Name = request.Name,
          Description = request.Description,
          StartDateUtc = request.StartDateUtc,
          EndDateUtc = request.EndDateUtc,
          CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
          CreatedAtUtc = DateTime.UtcNow
        };
    }
  }
}
