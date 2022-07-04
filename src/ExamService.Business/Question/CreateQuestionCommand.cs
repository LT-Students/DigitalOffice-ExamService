using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.FluentValidationExtensions;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;
using LT.DigitalOffice.ExamService.Business.Question.Interfaces;
using LT.DigitalOffice.ExamService.Validation.Question.Interfaces;

namespace LT.DigitalOffice.ExamService.Business.Question
{
  public class CreateQuestionCommand : ICreateQuestionCommand
  {
    private readonly IDbQuestionMapper _mapper;
    private readonly IQuestionRepository _repository;
    private readonly ICreateQuestionRequestValidator _validator;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IResponseCreator _responseCreator;

    public CreateQuestionCommand(
      IDbQuestionMapper mapper,
      IQuestionRepository repository,
      ICreateQuestionRequestValidator validator,
      IResponseCreator responseCreator,
      IHttpContextAccessor httpContextAccessor)
    {
      _mapper = mapper;
      _repository = repository;
      _validator = validator;
      _httpContextAccessor = httpContextAccessor;
      _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateQuestionRequest request)
    {
      if (!_validator.ValidateCustom(request, out List<string> errors) || !request.ExamId.HasValue)
      {
        return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.BadRequest, errors);
      }

      OperationResultResponse<Guid?> response = new();

      response.Body = await _repository.CreateAsync(_mapper.Map(request, request.ExamId.Value));

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