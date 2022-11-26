using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.ExamService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly IDataProvider _provider;

    public UserRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<bool> CreateAsync(List<DbUserAnswer> request)
    {
      if (request is null)
      {
        return false;
      }

      _provider.UsersAnswers.AddRange(request);
      await _provider.SaveAsync();

      return true;
    }

    public async Task<bool> CreateCourseAsync(DbUserCourse request)
    {
      if (request is null)
      {
        return false;
      }

      _provider.UsersCourses.Add(request);
      await _provider.SaveAsync();

      return true;
    }

    public Task<DbExam> GetAsync(Guid examId, Guid userId)
    {
      IQueryable<DbExam> query = _provider.Exams.AsQueryable();

      query = query
        .Include(e => e.Questions)
        .ThenInclude(q => q.UsersAnswers.Where(ua => ua.UserId == userId));

      query = query
        .Include(e => e.Questions)
        .ThenInclude(q => q.Answers);

      return query.FirstOrDefaultAsync(e => e.Id == examId);
    }

    public Task<List<DbExam>> FindCourseExamsAsync(Guid courseId, Guid userId)
    {
      return _provider.Exams
        .Where(e => e.StartDateUtc != null && e.StartDateUtc < DateTime.Now)
        .Include(e => e.Questions)
        .ThenInclude(q => q.UsersAnswers.Where(ua => ua.UserId == userId))
        .Where(e => e.CourseId == courseId).ToListAsync();
    }
  }
}
