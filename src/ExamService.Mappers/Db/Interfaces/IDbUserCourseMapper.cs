using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbUserCourseMapper
  {
    DbUserCourse Map(Guid courseId, Guid userId);
  }
}
