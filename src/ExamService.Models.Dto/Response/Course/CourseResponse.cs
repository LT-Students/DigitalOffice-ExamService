using LT.DigitalOffice.ExamService.Models.Dto.Models;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Response.Course
{
  public class CourseResponse
  {
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public bool IsActive { get; set; }
    public List<ExamInfo> Exams { get; set; }
  }
}
