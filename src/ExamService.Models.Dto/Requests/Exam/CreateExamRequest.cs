using LT.DigitalOffice.ExamService.Models.Dto.Requests.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam
{
  public record CreateExamRequest
  {
    public Guid CourseId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DeadLineUtc { get; set; }
    [Required]
    public List<CreateQuestionRequest> Questions { get; set; }
  }
}
