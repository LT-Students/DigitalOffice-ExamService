using ExamService.Models.Db;
using LT.DigitalOffice.Kernel.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef
{
  public class ExamServiceDbContext : DbContext, IDataProvider
  {
    public DbSet<DbAnswer> AnswersOptions { get; set; }
    public DbSet<DbExam> Exams { get; set; }
    public DbSet<DbQuestion> Questions { get; set; }
    public DbSet<DbUserAnswer> UsersAnswers { get; set; }

    public ExamServiceDbContext(DbContextOptions<ExamServiceDbContext> options)
      : base(options)
    {
    }

    // Fluent API is written here.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("LT.DigitalOffice.ExamService.Models.Db"));
    }

    public object MakeEntityDetached(object obj)
    {
      Entry(obj).State = EntityState.Detached;
      return Entry(obj).State;
    }

    async Task IBaseDataProvider.SaveAsync()
    {
      await SaveChangesAsync();
    }

    void IBaseDataProvider.Save()
    {
      SaveChanges();
    }

    public void EnsureDeleted()
    {
      Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
      return Database.IsInMemory();
    }
  }
}
