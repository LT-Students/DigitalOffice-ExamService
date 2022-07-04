using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ExamService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbExamMapper
  {
    DbExam Map(CreateExamRequest request);
  }
}
