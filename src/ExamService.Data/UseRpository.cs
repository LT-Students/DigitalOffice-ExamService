using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.ExamService.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data
{
  public class UseRpository : IUserRepository
  {
    private readonly IDataProvider _provider;

    public UseRpository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<bool> CreateAsync(List<DbUserAnswer> request)
    {
      if (request is null)
      {
        return false;
      }

      _provider.UsersAnswers.AddRange(request);
      await _provider.SaveAsync();

      return true;
    }
  }
}
