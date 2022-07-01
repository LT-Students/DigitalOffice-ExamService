using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface IUserRepository
  {
    Task<bool> CreateAsync(List<DbUserAnswer> request);
  }
}
