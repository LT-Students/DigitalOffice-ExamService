using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data
{
  public class ExamRepository : IExamRepository
  {
    private readonly IDataProvider _provider;

    public ExamRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbExam dbExam)
    {
      if (dbExam is null)
      {
        return null;
      }

      await _provider.Exams.AddAsync(dbExam);
      await _provider.SaveAsync();

      return dbExam.Id;
    }

    public Task<DbExam> GetAsync(Guid examId)
    {
      return _provider.Exams
        .Include(e => e.Questions).ThenInclude(q => q.Answers)
        .FirstOrDefaultAsync(e => e.Id == examId);
    }

    public async Task<(List<DbExam> exams, int totalCount)> FindAsync(FindExamsFilter filter)
    {
      if (filter is null)
      {
        return default;
      }

      IQueryable<DbExam> dbExams = _provider.Exams.AsQueryable();

      return (
        await dbExams.Skip(filter.SkipCount).Take(filter.TakeCount).ToListAsync(),
        await dbExams.CountAsync());
    }
  }
}
