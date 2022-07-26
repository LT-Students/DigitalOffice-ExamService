using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data
{
  public class CourseRepository : ICourseRepository
  {
    private readonly IDataProvider _provider;
    private readonly IHttpContextAccessor _httpContext;

    public CourseRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContext)
    {
      _provider = provider;
      _httpContext = httpContext;
    }

    public async Task<Guid?> CreateAsync(DbCourse dbCourse)
    {
      if (dbCourse is null)
      {
        return null;
      }

      _provider.Courses.Add(dbCourse);
      await _provider.SaveAsync();

      return dbCourse.Id;
    }

    public async Task<(List<DbCourse> courses, int totalCount)> FindAsync(FindCourseFilter filter)
    {
      IQueryable<DbCourse> query = _provider.Courses.AsQueryable();

      if (filter.UserCourses)
      {
        query = query.Where(c => c.Users.Any(cu => cu.UserId == _httpContext.HttpContext.GetUserId()));
      }

      return (
        await query.Skip(filter.SkipCount).Take(filter.TakeCount).ToListAsync(),
        await query.CountAsync());
    }

    public Task<DbCourse> GetAsync(GetCourseFilter filter)
    {
      if (filter is null)
      {
        return null;
      }

      IQueryable<DbCourse> query = _provider.Courses.AsQueryable();
      
      if (filter.IncludeUsers)
      {
        query = query.Include(c => c.Users);
      }

      return query
        .Include(c => c.Exams)
        .FirstOrDefaultAsync(c => c.Id == filter.CourseId);
    }
  }
}
