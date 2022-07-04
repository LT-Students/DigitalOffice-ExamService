using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record UserQuestionInfo
  {
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
    public List<AnswerInfo> Answers { get; set; }
    public UserAnswerInfo UserAnswer { get; set; }
  }
}
