using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.User
{
  public record CreateUserAnswerRequest
  {
    public Guid QuestionId { get; set; }
    public Guid? AnswerId { get; set; }
    public string Custom { get; set; }
  }
}
