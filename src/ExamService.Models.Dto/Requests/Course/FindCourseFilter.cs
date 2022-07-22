using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.ExamService.Models.Dto.Requests.Course
{
  public record FindCourseFilter : BaseFindFilter
  {
    [FromQuery(Name = "usercourses")]
    public bool UserCourses { get; set; } = false;
  }
}
