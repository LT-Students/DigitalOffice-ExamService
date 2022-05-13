using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Mappers.Db.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Requests;
using System;

namespace LT.DigitalOffice.ExamService.Mappers.Db
{
  public class DbExamMapper : IDbExamMapper
  {
    public DbExam Map(CreateExamRequest request)
    {
      return request is null
        ? null
        : new()
        {
          Id = Guid.NewGuid(),
          Name = request.Name,
          Description = request.Description
        };
    }
  }
}
