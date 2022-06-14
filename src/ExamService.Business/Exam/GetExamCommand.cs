using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class GetExamCommand : IGetExamCommand
  {
    private readonly IExamRepository _repository;
    private readonly IExamResponseMapper _mapper;
    private readonly IResponseCreator _responseCreator;

    public GetExamCommand(
      IExamRepository repository,
      IExamResponseMapper mapper,
      IResponseCreator responseCreator)
    {
      _repository = repository;
      _mapper = mapper;
      _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<ExamResponse>> ExecuteAsync(Guid examId)
    {
      DbExam dbExam = await _repository.GetAsync(examId);

      return dbExam is null
        ? _responseCreator.CreateFailureResponse<ExamResponse>(HttpStatusCode.NotFound)
        : new OperationResultResponse<ExamResponse>(_mapper.Map(dbExam));
    }
  }
}
