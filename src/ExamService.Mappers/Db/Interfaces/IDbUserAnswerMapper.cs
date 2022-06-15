using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.User;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbUserAnswerMapper
  {
    DbUserAnswer Map(CreateUserAnswerRequest request);
  }
}
