using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface ICourseRepository
  {
    Task<Guid?> CreateAsync(DbCourse dbCourse);

    Task<(List<DbCourse> courses, int totalCount)> FindAsync(FindCourseFilter filter);

    Task<DbCourse> GetAsync(GetCourseFilter filter);
  }
}
