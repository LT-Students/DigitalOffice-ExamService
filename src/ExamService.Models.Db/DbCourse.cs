using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Db
{
  public class DbCourse
  {
    public const string TableName = "Courses";
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public ICollection<DbExam> Exams { get; set; }
    public ICollection<DbUserCourse> Users { get; set; }

    public DbCourse()
    {
      Exams = new HashSet<DbExam>();
      Users = new HashSet<DbUserCourse>();
    }
  }

  public class DbCourseConfiguration : IEntityTypeConfiguration<DbCourse>
  {
    public void Configure(EntityTypeBuilder<DbCourse> builder)
    {
      builder
        .ToTable(DbCourse.TableName);

      builder
        .HasKey(q => q.Id);

      builder
        .HasMany(c => c.Exams)
        .WithOne(e => e.Course);

      builder
        .HasMany(c => c.Users)
        .WithOne(e => e.Course);
    }
  }
}
