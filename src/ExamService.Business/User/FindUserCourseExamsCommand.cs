using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.User
{
  public class FindUserCourseExamsCommand
  {
    private readonly IUserRepository _userRepository;
    private readonly IUserExamInfoMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FindUserCourseExamsCommand(
      IUserRepository userRepository,
      IUserExamInfoMapper mapper,
      IHttpContextAccessor httpContextAccessor)
    {
      _userRepository = userRepository;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<FindResultResponse<UserExamInfo>> ExecuteAsync(Guid courseId)
    {
      return new FindResultResponse<UserExamInfo>(
        body:
        (await _userRepository.FindCourseExamsAsync(courseId, _httpContextAccessor.HttpContext.GetUserId()))
        .Select(_mapper.Map).ToList());
    }
  }
}
