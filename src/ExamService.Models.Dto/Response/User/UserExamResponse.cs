using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Response.User
{
  public record UserExamResponse
  {
    public ExamInfo Exam { get; set; }
    public List<UserQuestionInfo> UserQuestions { get; set; }
    public bool IsFinished { get; set; }
    public int Score { get; set; }
    public DateTime? FinishedAtUtc { get; set; }
  }
}
