using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Response.User;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces
{
  [AutoInject]
  public interface IUserExamResponseMapper
  {
    UserExamResponse Map(DbExam exam);
  }
}
