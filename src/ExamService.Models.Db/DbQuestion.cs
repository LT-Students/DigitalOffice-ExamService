using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.ExamService.Models.Db
{
  public class DbQuestion
  {
    public const string TableName = "Questions";
    public Guid Id { get; set; }
    public Guid ExamId { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbExam Exam { get; set; }
    public ICollection<DbAnswer> Answers { get; set; }

    public DbQuestion()
    {
      Answers = new HashSet<DbAnswer>();
    }
  }

  public class DbQuestionConfiguration : IEntityTypeConfiguration<DbQuestion>
  {
    public void Configure(EntityTypeBuilder<DbQuestion> builder)
    {
      builder
        .ToTable(DbQuestion.TableName);

      builder
        .HasKey(q => q.Id);

      builder
        .HasOne(q => q.Exam)
        .WithMany(e => e.Questions);

      builder
        .HasMany(q => q.Answers)
        .WithOne(o => o.Question);
    }
  }
}
