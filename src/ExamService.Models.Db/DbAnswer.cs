using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ExamService.Models.Db
{
  public class DbAnswer
  {
    public const string TableName = "Answers";
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Option { get; set; }
    public bool IsCorrect { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbQuestion Question { get; set; }
  }

  public class DbAnswerOptionConfiguration : IEntityTypeConfiguration<DbAnswer>
  {
    public void Configure(EntityTypeBuilder<DbAnswer> builder)
    {
      builder
        .ToTable(DbAnswer.TableName);

      builder
        .HasKey(a => a.Id);

      builder
        .HasOne(a => a.Question)
        .WithMany(e => e.Answers);
    }
  }
}
