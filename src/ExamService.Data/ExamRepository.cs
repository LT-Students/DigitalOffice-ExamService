using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

      return dbExam.Id;
    }

    public async Task<List<DbExam>> FindAsync()
    {
      return await _provider.Exams.ToListAsync();
    }
  }
}
