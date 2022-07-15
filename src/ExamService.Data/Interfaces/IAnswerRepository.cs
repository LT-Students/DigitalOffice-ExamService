using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.ExamService.Models.Db;

namespace LT.DigitalOffice.ExamService.Data.Interfaces
{
  [AutoInject]
  public interface IAnswerRepository
  {
    Task<bool> EditAsync(Guid answerId, JsonPatchDocument<DbAnswer> request);
    Task<bool> IsCreator(Guid answerId);
  }
}