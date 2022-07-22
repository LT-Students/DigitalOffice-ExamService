using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Course;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Course
{
  public class GetCourseCommand : IGetCourseCommand
  {
    private readonly ICourseRepository _repository;
    private readonly ICourseResponseMapper _mapper;

    public GetCourseCommand(
      ICourseRepository repository,
      ICourseResponseMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<OperationResultResponse<CourseResponse>> ExecuteAsync(Guid examId)
    {
      return new OperationResultResponse<CourseResponse>(body: _mapper.Map(await _repository.GetAsync(examId)));
    }
  }
}
