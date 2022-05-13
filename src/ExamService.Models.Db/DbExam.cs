using System;

namespace ExamService.Models.Db
{
  public class DbExam
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
