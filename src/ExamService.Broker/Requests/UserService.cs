using ExamService.Broker.Requests.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.Kernel.BrokerSupport.Helpers;
using LT.DigitalOffice.Models.Broker.Requests.User;
using LT.DigitalOffice.Models.Broker.Responses.User;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Broker.Requests
{
  public class UserService : IUserService
  {
    private readonly IRequestClient<IGetUsersDataRequest> _rcGetUsersdata;
    private readonly ILogger<UserService> _logger;

    public UserService(
      IRequestClient<IGetUsersDataRequest> rcGetUsersdata,
      ILogger<UserService> logger)
    {
      _rcGetUsersdata = rcGetUsersdata;
      _logger = logger;
    }

    public async Task<List<UserInfo>> GetUsersDatasAsync(List<Guid> usersIds, List<string> errors)
    {
      return usersIds is null || !usersIds.Any()
        ? null
        : (await _rcGetUsersdata.ProcessRequest<IGetUsersDataRequest, IGetUsersDataResponse>(
            IGetUsersDataRequest.CreateObj(usersIds),
            errors,
            _logger))?.UsersData
              .Select(u => new UserInfo()
              {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MiddleName = u.MiddleName
              }).ToList();
    }
  }
}
