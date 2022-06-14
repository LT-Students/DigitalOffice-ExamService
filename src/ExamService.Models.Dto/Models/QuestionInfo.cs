using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record QuestionInfo
  {
    public Guid Id { get; set; }
    public Guid ExamId { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
    public List<AnswerInfo> Answers { get; set; }
  }
}
