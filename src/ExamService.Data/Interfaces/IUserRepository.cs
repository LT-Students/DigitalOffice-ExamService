using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface IUserRepository
  {
    Task<bool> CreateAsync(List<DbUserAnswer> request);
    Task<bool> CreateCourseAsync(DbUserCourse request);
    Task<DbExam> GetAsync(Guid examId, Guid userId);
    Task<List<DbExam>> FindCourseExamsAsync(Guid courseId, Guid userId);
  }
}
