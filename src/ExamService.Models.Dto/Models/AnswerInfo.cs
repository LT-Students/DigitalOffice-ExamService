using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record AnswerInfo
  {
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Answer { get; set; }
    public bool? IsCorrect { get; set; }
  }
}
