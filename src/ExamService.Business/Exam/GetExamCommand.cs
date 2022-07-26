using LT.DigitalOffice.ExamService.Broker.Requests.Interfaces;
using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using LT.DigitalOffice.Kernel.Helpers;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class GetExamCommand : IGetExamCommand
  {
    private readonly IExamRepository _repository;
    private readonly IExamResponseMapper _mapper;
    private readonly IUserService _userService;

    public GetExamCommand(
      IExamRepository repository,
      IExamResponseMapper mapper,
      IUserService userService)
    {
      _repository = repository;
      _mapper = mapper;
      _userService = userService;
    }

    public async Task<OperationResultResponse<ExamResponse>> ExecuteAsync(Guid examId)
    {
      DbExam dbExam = await _repository.GetAsync(examId);

      if (dbExam is null)
      {
        return ResponseCreatorStatic.CreateResponse<ExamResponse>(HttpStatusCode.NotFound);
      }

      OperationResultResponse<ExamResponse> response = new();
      List<Guid> creatorsIds = new() { dbExam.CreatedBy };

      response.Body = _mapper.Map(
      dbExam,
      (await _userService.GetUsersInfoAsync(creatorsIds, response.Errors)));

      return response;
    }
  }
}
