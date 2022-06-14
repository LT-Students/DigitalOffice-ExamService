using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Dto.Models
{
  public record ExamInfo
  {
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
