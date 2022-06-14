using LT.DigitalOffice.ExamService.Models.Dto.Requests.Answer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Question
{
  public record CreateQuestionRequest
  {
    public Guid? ExamId { get; set; }
    [Required]
    public string Subject { get; set; }
    public int Score { get; set; }
    public List<CreateAnswerRequest> Answers { get; set; }
  }
}
