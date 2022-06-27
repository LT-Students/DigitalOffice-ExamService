using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Responses.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Response.Exam;
using System.Collections.Generic;
using System.Linq;

namespace LT.DigitalOffice.ExamService.Mappers.Responses
{
  public class ExamResponseMapper : IExamResponseMapper
  {
    private readonly IExamInfoMapper _examInfoMapper;
    private readonly IQuestionInfoMapper _quetionInfoMapper;

    public ExamResponseMapper(
      IExamInfoMapper examInfoMapper,
      IQuestionInfoMapper quetionInfoMapper)
    {
      _examInfoMapper = examInfoMapper;
      _quetionInfoMapper = quetionInfoMapper;
    }

    public ExamResponse Map(DbExam dbExam, List<UserInfo> creators)
    {
      return dbExam is null
        ? null
        : new ExamResponse()
        {
          Exam = _examInfoMapper.Map(dbExam, creators?.FirstOrDefault(c => c.Id == dbExam.CreatedBy)),
          SubExams = dbExam.SubExams.Select(se => _examInfoMapper.Map(se, creators?.FirstOrDefault(c => c.Id == se.CreatedBy))).ToList(),
          Questions = dbExam.Questions?.Select(_quetionInfoMapper.Map).ToList()
        };
    }
  }
}
