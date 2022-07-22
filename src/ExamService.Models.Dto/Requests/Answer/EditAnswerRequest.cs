using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer
{
  public record EditAnswerRequest
  {
    public string Option { get; set; }
    public bool IsCorrect { get; set; }
  }
}