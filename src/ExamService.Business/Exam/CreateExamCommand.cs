using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class CreateExamCommand : ICreateExamCommand
  {
    private readonly IDbExamMapper _mapper;
    private readonly IExamRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateExamCommand(
      IDbExamMapper mapper,
      IExamRepository repository,
      IHttpContextAccessor httpContextAccessor)
    {
      _mapper = mapper;
      _repository = repository;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateExamRequest request)
    {
      OperationResultResponse<Guid?> response = new();

      response.Body = await _repository.CreateAsync(_mapper.Map(request));

      if (response.Body is null)
      {
        _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
      }
      else
      {
        _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
      }

      return response;
    }
  }
}
