using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.Kernel.Helpers;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User
{
  public class CreateUserCourseCommand : ICreateUserCourseCommand
  {
    private readonly IUserRepository _repository;
    private readonly IDbUserCourseMapper _mapper;

    public CreateUserCourseCommand(
      IUserRepository repository,
      IDbUserCourseMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid courseId, Guid userId)
    {

      return await _repository.CreateCourseAsync(_mapper.Map(courseId, userId))
        ? ResponseCreatorStatic.CreateResponse<bool>(HttpStatusCode.Created, body: true)
        : ResponseCreatorStatic.CreateResponse<bool>(HttpStatusCode.BadRequest, body: false);
    }
  }
}
