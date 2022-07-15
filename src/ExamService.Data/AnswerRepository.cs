using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;

namespace LT.DigitalOffice.ExamService.Data
{
  public class AnswerRepository : IAnswerRepository
  {
    private readonly IDataProvider _provider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AnswerRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
    {
      _provider = provider;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> EditAsync(Guid answerId, JsonPatchDocument<DbAnswer> request)
    {
      DbAnswer dbAnswer = await _provider.AnswersOptions.FirstOrDefaultAsync(answer => answer.Id == answerId);

      if (dbAnswer is null || request is null)
      {
        return false;
      }
      
      request.ApplyTo(dbAnswer);
      dbAnswer.ModifiedBy = _httpContextAccessor.HttpContext.GetUserId();
      dbAnswer.ModifiedAtUtc = DateTime.UtcNow;
      await _provider.SaveAsync();

      return true;
    }

    public async Task<bool> IsCreatorAsync(Guid answerId)
    {
      Guid userId = _httpContextAccessor.HttpContext.GetUserId();
      
      DbAnswer dbAnswer = await _provider.AnswersOptions.FirstOrDefaultAsync(
        answer => answer.Id == answerId && answer.CreatedBy == userId);

      return dbAnswer is not null;
    }
  }
}