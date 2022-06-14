using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record AnswerInfo
  {
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Option { get; set; }
  }
}
