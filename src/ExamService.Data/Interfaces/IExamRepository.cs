using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface IExamRepository
  {
    Task<Guid?> CreateAsync(DbExam dbExam);

    Task<DbExam> GetAsync(Guid examId);

    Task<(List<DbExam> exams, int totalCount)> FindAsync(FindExamsFilter filter);
  }
}
