using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface ICourseRepository
  {
    Task<Guid?> CreateAsync(DbCourse dbCourse);
  }
}
