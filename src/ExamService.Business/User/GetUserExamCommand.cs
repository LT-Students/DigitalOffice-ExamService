using LT.DigitalOffice.ExamService.Business.User.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Response.User;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User
{
  public class GetUserExamCommand : IGetUserExamCommand
  {
    private readonly IUserRepository _userRepository;
    private readonly IUserExamResponseMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetUserExamCommand(
      IUserRepository userRepository,
      IUserExamResponseMapper mapper,
      IHttpContextAccessor httpContextAccessor)
    {
      _userRepository = userRepository;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<OperationResultResponse<UserExamResponse>> ExecuteAsync(Guid examId)
    {
      return new OperationResultResponse<UserExamResponse>(
        body: _mapper.Map(await _userRepository.GetAsync(examId, _httpContextAccessor.HttpContext.GetUserId())));
    }
  }
}
