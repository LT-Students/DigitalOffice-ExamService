using ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Database;
using LT.DigitalOffice.Kernel.Enums;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef
{
  [AutoInject(InjectType.Scoped)]
  public interface IDataProvider : IBaseDataProvider
  {
    DbSet<DbAnswerOption> AnswersOptions { get; set; }
    DbSet<DbExam> Exams { get; set; }
    DbSet<DbQuestion> Questions { get; set; }
    DbSet<DbUserAnswer> UsersAnswers { get; set; }
  }
}
