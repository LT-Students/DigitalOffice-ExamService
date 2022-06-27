using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer
{
  public record CreateAnswerRequest
  {
    public Guid? QuestionId { get; set; }
    [Required]
    public string Answer { get; set; }
    public bool IsCorrect { get; set; }
  }
}
