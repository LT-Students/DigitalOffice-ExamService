using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.ExamService.Models.Db;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface IQuestionRepository
  {
    Task<Guid?> CreateAsync(DbQuestion question);
  }
}