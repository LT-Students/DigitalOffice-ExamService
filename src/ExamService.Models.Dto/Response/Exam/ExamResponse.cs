using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Response.Exam
{
  public record ExamResponse
  {
    public ExamInfo Exam { get; set; }
    public List<ExamInfo> SubExams { get; set; }
    public List<QuestionInfo> Questions { get; set; }
  }
}
