using LT.DigitalOffice.ExamService.Broker.Requests.Interfaces;
using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Course;
using LT.DigitalOffice.Kernel.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Course
{
  public class GetCourseCommand : IGetCourseCommand
  {
    private readonly ICourseRepository _repository;
    private readonly ICourseResponseMapper _mapper;
    private readonly IUserService _userService;

    public GetCourseCommand(
      ICourseRepository repository,
      ICourseResponseMapper mapper,
      IUserService userService)
    {
      _repository = repository;
      _mapper = mapper;
      _userService = userService;
    }

    public async Task<OperationResultResponse<CourseResponse>> ExecuteAsync(GetCourseFilter filter)
    {
      DbCourse course = await _repository.GetAsync(filter);

      OperationResultResponse<CourseResponse> response = new();
      response.Body = _mapper.Map(
        course,
        filter.IncludeUsers
          ? await _userService.GetUsersInfoAsync(course?.Users.Select(cu => cu.UserId).ToList(), response.Errors)
          : null);

      return response;
    }
  }
}
