using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record UserAnswerInfo
  {
    public Guid? AnswerId { get; set; }
    public string Custom { get; set; }
    public DateTime CreatedAtUtc { get; set; }
  }
}
