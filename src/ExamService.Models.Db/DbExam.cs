using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Db
{
  public class DbExam
  {
    public const string TableName = "Exams";
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DeadLineUtc { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbCourse Course { get; set; }
    public ICollection<DbQuestion> Questions { get; set; }

    public DbExam()
    {
      Course = new DbCourse();
    }
  }

  public class DbExamConfiguration : IEntityTypeConfiguration<DbExam>
  {
    public void Configure(EntityTypeBuilder<DbExam> builder)
    {
      builder
        .ToTable(DbExam.TableName);

      builder
        .HasKey(e => e.Id);

      builder
        .Property(e => e.Name)
        .IsRequired();
    }
  }
}
