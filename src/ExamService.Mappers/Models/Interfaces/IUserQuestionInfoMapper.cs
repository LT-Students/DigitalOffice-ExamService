﻿using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ExamService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface IUserQuestionInfoMapper
  {
    UserQuestionInfo Map(DbQuestion dbQuestion, bool showRightAnswers = false);
  }
}
