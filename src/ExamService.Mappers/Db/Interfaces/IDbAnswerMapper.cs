using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbAnswerMapper
  {
    DbAnswer Map(CreateAnswerRequest request, Guid questionId);
  }
}
