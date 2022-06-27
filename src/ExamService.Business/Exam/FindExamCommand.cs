using ExamService.Broker.Requests.Interfaces;
using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class FindExamCommand : IFindExamCommand
  {
    private readonly IExamRepository _repository;
    private readonly IExamInfoMapper _mapper;
    private readonly IUserService _userService;

    public FindExamCommand(
      IExamRepository repository,
      IExamInfoMapper mapper,
      IUserService userService)
    {
      _repository = repository;
      _mapper = mapper;
      _userService = userService;
    }

    public async Task<FindResultResponse<ExamInfo>> ExecuteAsync(FindExamsFilter filter)
    {
      (List<DbExam> exams, int totalCount) = await _repository.FindAsync(filter);

      FindResultResponse<ExamInfo> response = new(totalCount: totalCount);

      if (exams.Any())
      {
        List<UserInfo> users = await _userService.GetUsersDatasAsync(exams.Select(e => e.CreatedBy).ToList(), response.Errors);

        response.Body = exams.Select(e => _mapper.Map(e, users?.FirstOrDefault(u => u.Id == e.CreatedBy))).ToList();
      }

      return response;
    }
  }
}
