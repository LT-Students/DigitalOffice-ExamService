using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.ExamService.Models.Db;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data
{
  public class CourseRepository : ICourseRepository
  {
    private readonly IDataProvider _provider;

    public CourseRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbCourse dbCourse)
    {
      if (dbCourse is null)
      {
        return null;
      }

      await _provider.Courses.AddAsync(dbCourse);
      await _provider.SaveAsync();

      return dbCourse.Id;
    }
  }
}
