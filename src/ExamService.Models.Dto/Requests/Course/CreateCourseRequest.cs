using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Course
{
  public record CreateCourseRequest
  {
    public Guid? ParentId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
  }
}
