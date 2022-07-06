using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class UserExamInfoMapper : IUserExamInfoMapper
  {
    private readonly IExamInfoMapper _examMapper;

    public UserExamInfoMapper(
      IExamInfoMapper examMapper)
    {
      _examMapper = examMapper;
    }

    public UserExamInfo Map(DbExam dbExam)
    {
      if (dbExam is null)
      {
        return null;
      }

      UserExamInfo response = new();

      response.Exam = _examMapper.Map(dbExam);
      response.IsFinished = !dbExam.Questions.Any(q => q.UsersAnswers is null || !q.UsersAnswers.Any());
      response.FinishedAtUtc = response.IsFinished
        ? dbExam.Questions.FirstOrDefault().UsersAnswers.FirstOrDefault().CreatedAtUtc
        : null;

      return response;
    }
  }
}
