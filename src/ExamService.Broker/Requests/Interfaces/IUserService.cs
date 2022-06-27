using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamService.Broker.Requests.Interfaces
{
  [AutoInject]
  public interface IUserService
  {
    Task<List<UserInfo>> GetUsersDatasAsync(List<Guid> usersIds, List<string> errors);
  }
}
