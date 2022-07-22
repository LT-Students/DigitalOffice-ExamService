using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.Responses;
using MassTransit.Initializers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Course
{
  public class FindCourseCommand : IFindCourseCommand
  {
    private readonly ICourseInfoMapper _mapper;
    private readonly ICourseRepository _repository;

    public FindCourseCommand(
      ICourseInfoMapper mapper,
      ICourseRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    public async Task<FindResultResponse<CourseInfo>> ExecuteAsync(FindCourseFilter filter)
    {
      (List<DbCourse> courses, int totalCount) = await _repository.FindAsync(filter);

      return new FindResultResponse<CourseInfo>(
        body: courses.Select(_mapper.Map).ToList(),
        totalCount: totalCount);
    }
  }
}
