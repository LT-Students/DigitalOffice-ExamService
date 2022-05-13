using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Responses;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class CreateExamCommand : ICreateExamCommand
  {
    private readonly IDbExamMapper _mapper;
    private readonly IExamRepository _repository;

    public CreateExamCommand(
      IDbExamMapper mapper,
      IExamRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateExamRequest request)
    {
      OperationResultResponse<Guid?> response = new();

      response.Body = await _repository.CreateAsync(_mapper.Map(request));

      return response;
    }
  }
}
