using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.ExamService.Models.Db
{
  public class DbUserCourse
  {
    public const string TableName = "UsersCourses";
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public bool IsActive { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbCourse Course { get; set; }

    public DbUserCourse()
    {
      Course = new DbCourse();
    }
  }

  public class DbUserCourseConfiguration : IEntityTypeConfiguration<DbUserCourse>
  {
    public void Configure(EntityTypeBuilder<DbUserCourse> builder)
    {
      builder
        .ToTable(DbUserCourse.TableName);

      builder
        .HasKey(q => q.Id);
    }
  }
}
