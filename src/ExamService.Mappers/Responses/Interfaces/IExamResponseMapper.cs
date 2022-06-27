using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces
{
  [AutoInject]
  public interface IExamResponseMapper
  {
    ExamResponse Map(DbExam dbExam, List<UserInfo> creators);
  }
}
