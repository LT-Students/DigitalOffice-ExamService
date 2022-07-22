using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbCourseMapper
  {
    DbCourse Map(CreateCourseRequest request);
  }
}
