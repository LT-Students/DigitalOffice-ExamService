using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Response.User;

namespace LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces
{
  public interface IUserExamResponseMapper
  {
    UserExamResponse Map(DbExam exam);
  }
}
