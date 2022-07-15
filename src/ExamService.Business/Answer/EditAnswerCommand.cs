using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.ExamService.Business.Answer.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Patch.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.ExamService.Validation.Answer.Interfaces;

namespace LT.DigitalOffice.ExamService.Business.Answer
{
  public class EditAnswerCommand : IEditAnswerCommand
  {
    private readonly IResponseCreator _responseCreator;
    private readonly IEditAnswerRequestValidator _answerValidator;
    private readonly IAnswerRepository _answerRepository;
    private readonly IPatchDbAnswerMapper _mapper;

    public EditAnswerCommand(
      IResponseCreator responseCreator,
      IEditAnswerRequestValidator answerValidator,
      IAnswerRepository answerRepository,
      IPatchDbAnswerMapper mapper)
    {
      _responseCreator = responseCreator;
      _answerValidator = answerValidator;
      _answerRepository = answerRepository;
      _mapper = mapper;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid answerId, JsonPatchDocument<EditAnswerRequest> request)
    {
      ValidationResult validationResult = await _answerValidator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest,
          validationResult.Errors.Select(validationFailure => validationFailure.ErrorMessage).ToList());
      }

      OperationResultResponse<bool> response = new();

      response.Body = await _answerRepository.EditAsync(answerId, _mapper.Map(request));
      
      if (!response.Body)
      {
        _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest);
      }

      return response;
    }
  }
}