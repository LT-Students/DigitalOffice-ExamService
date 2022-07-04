using LT.DigitalOffice.Kernel.BrokerSupport.Attributes.ParseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.ExamService.Models.Db
{
  public class DbUserAnswer
  {
    public const string TableName = "UsersAnswers";
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid? AnswerId { get; set; }
    public string Custom { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }
    [IgnoreParse]
    public DbQuestion Question { get; set; }

    public DbUserAnswer()
    {
      Question = new DbQuestion();
    }
  }

  public class DbUserAnswerConfiguration : IEntityTypeConfiguration<DbUserAnswer>
  {
    public void Configure(EntityTypeBuilder<DbUserAnswer> builder)
    {
      builder
        .ToTable(DbUserAnswer.TableName);

      builder
        .HasKey(q => q.Id);

      builder
        .HasOne(ua => ua.Question)
        .WithMany(q => q.UsersAnswers);
    }
  }
}
