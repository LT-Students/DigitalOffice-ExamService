using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;
using LT.DigitalOffice.Kernel.Attributes;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbQuestionMapper
  {
    DbQuestion Map(CreateQuestionRequest request, Guid examId);
  }
}
