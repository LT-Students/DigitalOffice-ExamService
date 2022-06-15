using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
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
    private readonly IResponseCreator _responseCreator;

    public CreateUserAnswerCommand(
      IDbUserAnswerMapper mapper,
      IUserRepository repository,
      IResponseCreator responseCreator)
    {
      _mapper = mapper;
      _repository = repository;
      _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(List<CreateUserAnswerRequest> request)
    {
      OperationResultResponse<bool> response = new();
      return
        await _repository.CreateAsync(request.Select(_mapper.Map).ToList())
        ? new OperationResultResponse<bool>(body: true)
        : _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest);
    }
  }
}
