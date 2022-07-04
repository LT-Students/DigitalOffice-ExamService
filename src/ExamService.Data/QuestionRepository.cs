using System;
using System.Threading.Tasks;
using LT.DigitalOffice.ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;

namespace LT.DigitalOffice.ExamService.Data
{
  public class QuestionRepository : IQuestionRepository
  {
    private readonly IDataProvider _provider;

    public QuestionRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbQuestion question)
    {
      if (question is null)
      {
        return null;
      }
      
      _provider.Questions.Add(question);
      await _provider.SaveAsync();
      
      return question.Id;
    }
  }
}