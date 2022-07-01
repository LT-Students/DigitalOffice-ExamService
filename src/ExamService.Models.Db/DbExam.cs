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
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbExam Parent { get; set; }
    public ICollection<DbExam> SubExams { get; set; }
    public ICollection<DbQuestion> Questions { get; set; }

    public DbExam()
    {
      SubExams = new HashSet<DbExam>();
      Questions = new HashSet<DbQuestion>();
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

      builder.HasOne(e => e.Parent)
        .WithMany(e => e.SubExams)
        .HasForeignKey(e => e.ParentId)
        .IsRequired(false);
    }
  }
}
