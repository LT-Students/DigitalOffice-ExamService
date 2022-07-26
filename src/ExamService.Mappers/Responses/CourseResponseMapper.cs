using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Course;
using System.Collections.Generic;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Responses
{
  public class CourseResponseMapper : ICourseResponseMapper
  {
    private readonly IExamInfoMapper _examInfoMapper;

    public CourseResponseMapper(
      IExamInfoMapper examInfoMapper)
    {
      _examInfoMapper = examInfoMapper;
    }

    public CourseResponse Map(DbCourse dbCourse, List<UserInfo> users = null)
    {
      return dbCourse is null
        ? null
        : new CourseResponse()
        {
          Id = dbCourse.Id,
          ParentId = dbCourse.ParentId,
          Name = dbCourse.Name,
          Description = dbCourse.Description,
          StartDateUtc = dbCourse.StartDateUtc,
          EndDateUtc = dbCourse.EndDateUtc,
          IsActive = dbCourse.IsActive,
          Exams = dbCourse.Exams?.Select(e => _examInfoMapper.Map(e)).ToList(),
          Users = users
        };
    }
  }
}
