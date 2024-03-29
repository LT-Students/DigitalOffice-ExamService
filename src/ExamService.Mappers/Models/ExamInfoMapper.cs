﻿using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;

namespace LT.DigitalOffice.ExamService.Mappers.Models
{
  public class ExamInfoMapper : IExamInfoMapper
  {
    public ExamInfo Map(DbExam dbExam, UserInfo creator = null)
    {
      return dbExam is null
        ? null
        : new ExamInfo()
        {
          Id = dbExam.Id,
          ParentId = dbExam.CourseId,
          Name = dbExam.Name,
          Description = dbExam.Description,
          StartDateUtc = dbExam.StartDateUtc,
          DeadLineUtc = dbExam.DeadLineUtc,
          CreatorInfo = creator,
        };
    }
  }
}
