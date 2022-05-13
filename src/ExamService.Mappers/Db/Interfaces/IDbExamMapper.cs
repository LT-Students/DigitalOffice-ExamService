using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  public interface IDbExamMapper
  {
    DbExam Map(CreateExamRequest request);
  }
}
