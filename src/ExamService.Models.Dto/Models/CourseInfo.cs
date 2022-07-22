using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record CourseInfo
  {
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
  }
}
