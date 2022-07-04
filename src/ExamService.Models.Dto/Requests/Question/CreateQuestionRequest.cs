using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Question
{
  public record CreateQuestionRequest
  {
    public Guid? ExamId { get; set; }
    [Required]
    public string Subject { get; set; }
    public int Score { get; set; }
    [Required]
    public List<CreateAnswerRequest> Answers { get; set; }
  }
}
