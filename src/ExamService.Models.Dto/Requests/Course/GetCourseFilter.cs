using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Course
{
  public record GetCourseFilter
  {
    [FromQuery(Name = "courseId")]
    public Guid CourseId { get; set; }

    [FromQuery(Name = "includeusers")]
    public bool IncludeUsers { get; set; } = false;
  }
}
