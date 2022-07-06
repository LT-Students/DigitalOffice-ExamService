using LT.DigitalOffice.ExamService.Business.Course.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Course;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Helpers;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Course
{
  public class CreateCourseCommand : ICreateCourseCommand
  {
    private readonly IDbCourseMapper _mapper;
    private readonly ICourseRepository _repository;
    private readonly IAccessValidator _accessValidator;

    public CreateCourseCommand(
      IDbCourseMapper mapper,
      ICourseRepository repository,
      IAccessValidator accessValidator)
    {
      _mapper = mapper;
      _repository = repository;
      _accessValidator = accessValidator;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateCourseRequest request)
    {
      return await _accessValidator.IsAdminAsync()
        ? new OperationResultResponse<Guid?>(body: await _repository.CreateAsync(_mapper.Map(request)))
        : ResponseCreatorStatic.CreateResponse<Guid?>(HttpStatusCode.Forbidden);
    }
  }
}
