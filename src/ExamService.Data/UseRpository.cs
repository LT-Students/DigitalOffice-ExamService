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
  public class UserRpository : IUserRepository
  {
    private readonly IDataProvider _provider;

    public UserRpository(IDataProvider provider)
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

    public async Task<DbExam> GetAsync(Guid examId, Guid userId)
    {
      return await _provider.Exams
        .Include(e => e.Questions)
        .ThenInclude(q => q.UsersAnswers.Where(ua => ua.UserId == userId))
        .FirstOrDefaultAsync(e => e.Id == examId);
    }

    public async Task<List<DbExam>> FindCourseExamsAsync(Guid courseId, Guid userId)
    {
      return await _provider.Exams
        .Include(e => e.Questions)
        .ThenInclude(q => q.UsersAnswers.Where(ua => ua.UserId == userId))
        .Where(e => e.CourseId == courseId).ToListAsync();
    }
  }
}
