using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class CourseInfoMapper : ICourseInfoMapper
  {
    public CourseInfo Map(DbCourse dbCourse)
    {
      return dbCourse is null
        ? null
        : new CourseInfo()
        {
          Id = dbCourse.Id,
          ParentId = dbCourse.ParentId,
          Name = dbCourse.Name,
          IsActive = dbCourse.IsActive
        };
    }
  }
}
