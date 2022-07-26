using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Course;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces
{
  [AutoInject]
  public interface ICourseResponseMapper
  {
    CourseResponse Map(DbCourse dbCourse, List<UserInfo> users = null);
  }
}
