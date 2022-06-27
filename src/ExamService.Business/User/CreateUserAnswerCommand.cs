using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Helpers;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User
{
  public class CreateUserAnswerCommand : ICreateUserAnswerCommand
  {
    private readonly IDbUserAnswerMapper _mapper;
    private readonly IUserRepository _repository;

    public CreateUserAnswerCommand(
      IDbUserAnswerMapper mapper,
      IUserRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(List<CreateUserAnswerRequest> request)
    {
      return
        await _repository.CreateAsync(request.Select(_mapper.Map).ToList())
        ? ResponseCreatorStatic.CreateResponse<bool>(HttpStatusCode.Created, body: true)
        : ResponseCreatorStatic.CreateResponse<bool>(HttpStatusCode.BadRequest);
    }
  }
}
