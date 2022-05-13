using ExamService.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  public interface IExamRepository
  {
    Task<Guid?> CreateAsync(DbExam dbExam);

    Task<List<DbExam>> FindAsync();
  }
}
