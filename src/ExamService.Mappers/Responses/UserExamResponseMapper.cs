using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Response.User;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Responses
{
  public class UserExamResponseMapper
  {
    private readonly IExamInfoMapper _examMapper;
    private readonly IUserQuestionMapper _questionMapper;

    public UserExamResponseMapper(
      IExamInfoMapper examMapper,
      IUserQuestionMapper questionMapper)
    {
      _examMapper = examMapper;
      _questionMapper = questionMapper;
    }

    public UserExamResponse Map(
      DbExam dbExam)
    {
      if (dbExam is null)
      {
        return null;
      }

      UserExamResponse response = new();

      response.Exam = _examMapper.Map(dbExam);
      response.IsFinished = !dbExam.Questions.Any(q => q.UsersAnswers is null || !q.UsersAnswers.Any());

      if (response.IsFinished)
      {
        response.UserQuestions = dbExam.Questions.Select(q => _questionMapper.Map(dbQuestion: q, showRightAnswers: true)).ToList();
        response.Score = dbExam.Questions
          .Where(q => q.Answers.Where(a => a.IsCorrect).All(a => q.UsersAnswers.Select(ua => ua.AnswerId).ToList().Contains(a.Id)))
          .Select(q => q.Score)
          .Sum();

        response.FinishedAtUtc = dbExam.Questions.FirstOrDefault().UsersAnswers.FirstOrDefault().CreatedAtUtc;
      }
      else
      {
        response.UserQuestions = dbExam.Questions.Select(q => _questionMapper.Map(dbQuestion: q, showRightAnswers: false)).ToList();
      }

      return response;
    }
  }
}
