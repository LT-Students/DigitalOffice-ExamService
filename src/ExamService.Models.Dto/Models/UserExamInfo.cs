using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record UserExamInfo
  {
    public ExamInfo Exam { get; set; }
    public bool IsFinished { get; set; }
    public DateTime? FinishedAtUtc { get; set; }
  }
}
